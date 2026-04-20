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

        #endregion
    }
}
