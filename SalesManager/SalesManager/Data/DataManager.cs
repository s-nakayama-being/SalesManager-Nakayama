using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using SalesManager.Models;

namespace SalesManager.Data {
    /// <summary>
    /// 各種ファイルを読み込み、データモデルのリストとして保持するクラス
    /// </summary>
    public class DataManager {
        private static readonly (string C_FilePattern, string C_DisplayName) C_StoreConfig = ("stores.csv", "店舗マスタ");
        private static readonly (string C_FilePattern, string C_DisplayName) C_ProductConfig = ("products.csv", "製品マスタ");
        private static readonly (string C_FilePattern, string C_DisplayName) C_InventoryConfig = ("inventory.csv", "在庫データ");
        private static readonly (string C_FilePattern, string C_DisplayName) C_SaleConfig = ("Sales_*.csv", "売上データ");

        private static readonly CsvConfiguration C_Config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture) {
            HasHeaderRecord = true,
            PrepareHeaderForMatch = args => args.Header.ToLowerInvariant()
        };

        /// <summary>
        /// 店舗マスタデータの初期化
        /// </summary>
        public static IReadOnlyList<StoreModel> FStores { get; private set; } = new List<StoreModel>();

        /// <summary>
        /// 商品マスタデータの初期化
        /// </summary>
        public static IReadOnlyList<ProductModel> FProducts { get; private set; } = new List<ProductModel>();
        
        /// <summary>
        /// 在庫データの初期化
        /// </summary>
        public static IReadOnlyList<InventoryModel> FInventories { get; private set; } = new List<InventoryModel>();

        /// <summary>
        /// 売上データの初期化
        /// </summary>
        public static IReadOnlyList<SaleModel> FSales { get; private set; } = new List<SaleModel>();

        /// <summary>
        /// 指定されたフォルダ内の全対象ファイルを読み込み、各データモデルのリストに格納
        /// </summary>
        /// <param name="vFolderPath">対象ファイルが配置されているフォルダパス</param>
        /// <returns>非同期タスク</returns>
        public static async Task LoadAll(string vFolderPath) {
            await Task.Run(() => {
                var wStores = FetchFile<StoreModel>(vFolderPath, C_StoreConfig.C_FilePattern, C_StoreConfig.C_DisplayName);
                var wProducts = FetchFile<ProductModel>(vFolderPath, C_ProductConfig.C_FilePattern, C_ProductConfig.C_DisplayName);
                var wInventories = FetchFile<InventoryModel>(vFolderPath, C_InventoryConfig.C_FilePattern, C_InventoryConfig.C_DisplayName);
                var wSales = FetchFile<SaleModel>(vFolderPath, C_SaleConfig.C_FilePattern, C_SaleConfig.C_DisplayName);

                FStores = wStores;
                FProducts = wProducts;
                FInventories = wInventories;
                FSales = wSales;
            });
        }

        private static List<T> FetchFile<T>(string vFolderPath, string vFilePattern, string vDisplayName) {
            try {
                var wFiles = Directory.GetFiles(vFolderPath, vFilePattern);

                if (wFiles.Length == 0) throw new FileNotFoundException($"{vDisplayName}が見つかりません。指定されたフォルダにファイルが存在するか確認してください。");

                if (wFiles.Length > 1) throw new InvalidDataException($"{vDisplayName}が複数見つかりました。処理対象が特定できないため、フォルダ内には対象ファイルのみ配置してください。");

                var wResult = ReadCsv<T>(wFiles.Single());

                if (wResult.Count == 0) throw new InvalidDataException($"{vDisplayName}にデータが存在しません。ファイルの内容を確認してください。");

                return wResult;

            } catch (FileNotFoundException) {
                throw;

            } catch (DirectoryNotFoundException) {
                throw new DirectoryNotFoundException($"指定されたフォルダが見つかりません。パスを確認してください。");

            } catch (UnauthorizedAccessException) {
                throw new UnauthorizedAccessException($"{vDisplayName}へのアクセス権限がありません。ファイルのアクセス権限を確認してください。");

            } catch (IOException) {
                throw new IOException($"{vDisplayName}が他のプログラムで開かれています。ファイルを閉じてから再度実行してください。");

            } catch (CsvHelperException) {
                throw new InvalidDataException($"{vDisplayName}のデータ形式に誤りがあります。ファイルの内容を確認してください。");
            }
        }

        private static List<T> ReadCsv<T>(string vFilePath) {
            using (var wReader = new StreamReader(vFilePath, Encoding.UTF8))
            using (var wCsv = new CsvReader(wReader, C_Config)) {
                wCsv.Context.RegisterClassMap<PreFixRemovingMap<T>>();
                return wCsv.GetRecords<T>().ToList();
            }
        }

        private class PreFixRemovingMap<T> : ClassMap<T> {
            public PreFixRemovingMap() {
                AutoMap(System.Globalization.CultureInfo.InvariantCulture);

                foreach (var wMap in MemberMaps) {
                    string wPropName = wMap.Data.Member.Name;

                    if (wPropName.StartsWith("F") && wPropName.Length > 1) wMap.Name(wPropName.Substring(1));
                }
            }
        }
    }
}