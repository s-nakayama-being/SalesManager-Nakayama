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
        /// <summary>
        /// 集計結果および発注候補リストを指定されたフォルダにファイル出力
        /// </summary>
        /// <param name="vResultList">集計結果のリスト</param>
        /// <param name="vPeriodString">対象期間</param>
        /// <param name="vOutputFolderPath">出力先のフォルダパス</param>
        public static void Export(
            List<AggregatedSalesModel> vResultList,
            string vPeriodString,
            string vOutputFolderPath) {

            Directory.CreateDirectory(vOutputFolderPath);

            var wAggregatedSalesPath = Path.Combine(vOutputFolderPath, $"AggregatedSales_{vPeriodString}.csv");
            WriteCsv(wAggregatedSalesPath, vResultList);

            var wRestockList = vResultList.Where(x => x.IsRestockNeeded).ToList();
            if (wRestockList.Any()) {
                var wRestockListPath = Path.Combine(vOutputFolderPath, $"RestockList_{vPeriodString}.csv");
                WriteCsv(wRestockListPath, wRestockList);
            }
        }

        private static void WriteCsv<T>(string vFilePath, List<T> vData) {
            var wConfig = new CsvConfiguration(CultureInfo.InvariantCulture) {
                HasHeaderRecord = true
            };

            using (var wWriter = new StreamWriter(vFilePath, false, new UTF8Encoding(true)))
            using (var wCsv = new CsvWriter(wWriter, wConfig)) {
                wCsv.WriteRecords(vData);
            }
        }
    }
}
