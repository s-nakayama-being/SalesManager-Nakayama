using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using SalesManager.Models;
using SalesManager.Services;

namespace SalesManager.Data {
    /// <summary>
    /// 各種ファイルを読み込み、データモデルのリストとして保持するクラス
    /// </summary>
    public class DataManager {
        #region フィールド・初期化

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
        public static IReadOnlyList<StoreModel> Stores { get; private set; } = new List<StoreModel>();

        /// <summary>
        /// 商品マスタデータの初期化
        /// </summary>
        public static IReadOnlyList<ProductModel> Products { get; private set; } = new List<ProductModel>();

        /// <summary>
        /// 在庫データの初期化
        /// </summary>
        public static IReadOnlyList<InventoryModel> Inventories { get; private set; } = new List<InventoryModel>();

        /// <summary>
        /// 売上データの初期化
        /// </summary>
        public static IReadOnlyList<SaleModel> Sales { get; private set; } = new List<SaleModel>();

        #endregion

        #region publicメソッド

        /// <summary>
        /// 指定されたフォルダ内の全対象ファイルを読み込み、各データモデルのリストに格納
        /// </summary>
        /// <param name="vFolderPath">対象ファイルが配置されているフォルダパス</param>
        /// <returns>非同期タスク</returns>
        public static async Task<(string FFileName, string FPeriod)> LoadAll(string vFolderPath) {
            return await Task.Run(() => {
                var wStoreFilePath = GetFilePath(vFolderPath, C_StoreConfig.C_FilePattern, C_StoreConfig.C_DisplayName);
                var wProductFilePath = GetFilePath(vFolderPath, C_ProductConfig.C_FilePattern, C_ProductConfig.C_DisplayName);
                var wInventoryFilePath = GetFilePath(vFolderPath, C_InventoryConfig.C_FilePattern, C_InventoryConfig.C_DisplayName);
                var wSaleFilePath = GetFilePath(vFolderPath, C_SaleConfig.C_FilePattern, C_SaleConfig.C_DisplayName);

                var wSalesFileName = Path.GetFileName(wSaleFilePath);
                var wStartDate = SalesValidator.ParseStartDate(wSalesFileName);
                var wTargetPeriod = $"{wStartDate:yyyyMMdd}_{(wStartDate.AddDays(SalesValidator.C_TargetPeriodDays - 1)):yyyyMMdd}";

                var wStore = ReadCsv<StoreModel>(wStoreFilePath, C_StoreConfig.C_DisplayName);
                var wProduct = ReadCsv<ProductModel>(wProductFilePath, C_ProductConfig.C_DisplayName);
                var wInventories = ReadCsv<InventoryModel>(wInventoryFilePath, C_InventoryConfig.C_DisplayName);
                var wSales = ReadCsv<SaleModel>(wSaleFilePath, C_SaleConfig.C_DisplayName);

                SalesValidator.EnsureWithinRange(wSales, wStartDate);

                Stores = wStore;
                Products = wProduct;
                Inventories = wInventories;
                Sales = wSales;

                return (FFileName: wSalesFileName, FPeriod: wTargetPeriod);
            });
        }

        #endregion

        #region privateメソッド

        private static string GetFilePath(string vFolderPath, string vFilePattern, string vDisplay) {
            try {
                var wFiles = Directory.GetFiles(vFolderPath, vFilePattern);

                if (!wFiles.Any()) throw new FileNotFoundException($"{vDisplay}が見つかりません。指定されたフォルダにファイルが存在するか確認してください。");
                if (wFiles.Length > 1) throw new InvalidDataException($"{vDisplay}が複数見つかりました。処理対象が特定できないため、フォルダ内には対象ファイルのみ配置してください。");
                return wFiles.Single();
            } catch (FileNotFoundException) {
                throw;
            } catch (DirectoryNotFoundException) {
                throw new DirectoryNotFoundException($"指定されたフォルダが見つかりません。パスを確認してください。");
            }
        }

        private static List<T> ReadCsv<T>(string vFilePath, string vDisplayName) {
            try {
                using (var wReader = new StreamReader(vFilePath, Encoding.UTF8))
                using (var wCsv = new CsvReader(wReader, C_Config)) {
                    var wResult = wCsv.GetRecords<T>().ToList();
                    if (!wResult.Any()) throw new InvalidDataException($"{vDisplayName}にデータが存在しません。ファイルの内容を確認してください。");
                    return wResult;
                }
            } catch (UnauthorizedAccessException) {
                throw new UnauthorizedAccessException($"{vDisplayName}へのアクセス権限がありません。ファイルのアクセス権限を確認してください。");
            } catch (IOException) {
                throw new IOException($"{vDisplayName}が他のプログラムで開かれています。ファイルを閉じてから再度実行してください。");
            } catch (CsvHelperException) {
                throw new InvalidDataException($"{vDisplayName}の形式が正しくありません。ファイルの内容を確認してください。");
            }
        }

        #endregion
    }
}