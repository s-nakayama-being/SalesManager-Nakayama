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

        public static void ExportAggregatedSales(List<AggregatedSalesModel> vResultList, string vPeriodString, string vOutputFolderPath) {
            Directory.CreateDirectory(vOutputFolderPath);

            var wFilePath = Path.Combine(vOutputFolderPath, $"AggregatedSales_{vPeriodString}.csv");

            WriteCsv(wFilePath, vResultList);
        }

        public static void ExportRestockList(List<AggregatedSalesModel> vResultList, string vPeriodString, string vOutputFolderPath) {
            var wRestockList = vResultList.Where(x => x.IsRestockNeeded).ToList();

            if (!wRestockList.Any()) return;

            Directory.CreateDirectory(vOutputFolderPath);

            var wFilePath = Path.Combine(vOutputFolderPath, $"RestockList_{vPeriodString}.csv");

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
