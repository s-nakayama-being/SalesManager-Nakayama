using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using SalesManager.Models;

namespace SalesManager.Data {
    /// <summary>
    /// 集計結果等のデータを外部ファイルとして出力するクラス
    /// </summary>
    public static class DataExporter {
        #region フィールド

        private static readonly string C_FooterLabel = "Sum";

        #endregion

        #region publicメソッド

        /// <summary>
        /// 集計結果を外部ファイルとして出力
        /// </summary>
        /// <param name="vResultList">集計結果のリスト</param>
        /// <param name="vTargetPeriod">対象期間</param>
        /// <param name="vOutputFolderPath">出力先フォルダのパス</param>
        public static void ExportAggregatedSales(List<AggregatedSalesModel> vResultList, string vTargetPeriod, string vOutputFolderPath) {
            Directory.CreateDirectory(vOutputFolderPath);

            var wFilePath = Path.Combine(vOutputFolderPath, $"AggregatedSales_{vTargetPeriod}.csv");

            WriteCsv(wFilePath, vResultList);

            AppendFooter(wFilePath, vResultList);
        }

        /// <summary>
        /// 在庫発注が必要な商品を抽出して外部ファイルとして出力
        /// </summary>
        /// <param name="vResultList">集計結果のリスト</param>
        /// <param name="vTargetPeriod">対象期間</param>
        /// <param name="vOutputFolderPath">出力先フォルダのパス</param>
        public static void ExportRestockList(List<AggregatedSalesModel> vResultList, string vTargetPeriod, string vOutputFolderPath) {
            var wRestockList = vResultList.Where(x => x.IsRestockNeeded).ToList();

            if (!wRestockList.Any()) return;

            Directory.CreateDirectory(vOutputFolderPath);

            var wFilePath = Path.Combine(vOutputFolderPath, $"RestockList_{vTargetPeriod}.csv");

            WriteCsv(wFilePath, wRestockList);
        }

        #endregion

        #region privateメソッド

        private static void WriteCsv<T>(string vFilePath, List<T> vData) {
            var wConfig = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = true
            };

            using (var wWriter = new StreamWriter(vFilePath, false, new UTF8Encoding(true)))
            using (var wCsv = new CsvWriter(wWriter, wConfig)) {
                wCsv.WriteRecords(vData);
            }
        }

        private static void AppendFooter(string vFilePath, List<AggregatedSalesModel> vData) {
            var wProps = typeof(AggregatedSalesModel).GetProperties()
                .Where(x => !Attribute.IsDefined(x, typeof(CsvHelper.Configuration.Attributes.IgnoreAttribute))).ToList();

            var wAmountIdx = wProps.FindIndex(x => x.Name == nameof(AggregatedSalesModel.TotalSalesAmount));

            if (wAmountIdx == -1) throw new InvalidOperationException($"{nameof(AggregatedSalesModel.TotalSalesAmount)}列が見つかりませんでした。");

            var wFooter = new string[wProps.Count];
            wFooter[wAmountIdx] = vData.Sum(x => x.TotalSalesAmount).ToString(CultureInfo.InvariantCulture);

            if (wAmountIdx > 0) wFooter[wAmountIdx - 1] = C_FooterLabel;

            var wConfig = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = false
            };

            using (var wWriter = new StreamWriter(vFilePath, true, new UTF8Encoding(true)))
            using (var wCsv = new CsvWriter(wWriter, wConfig)) {
                foreach (var wValue in wFooter) wCsv.WriteField(wValue);
                wCsv.NextRecord();
            }
        }

        #endregion
    }
}
