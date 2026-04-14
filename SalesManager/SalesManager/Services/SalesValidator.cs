using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SalesManager.Models;

namespace SalesManager.Services {
    /// <summary>
    /// 売上データの妥当性を検証するクラス
    /// </summary>
    public static class SalesValidator {
        private const int C_TargetPeriodDays = 7;

        /// <summary>
        /// ファイル名から基準日を解析
        /// </summary>
        /// <param name="vFileName">解析対象のファイル名</param>
        /// <returns>基準日</returns>
        public static DateTime ParseStartDate(string vFileName) {
            var wFileName = Path.GetFileNameWithoutExtension(vFileName);
            var wParts = wFileName.Split('_');

            if (wParts.Length < 2 || !DateTime.TryParseExact(wParts[1], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var wStartDate))
                throw new InvalidDataException($"ファイル名({vFileName})から開始日を解析できませんでした。ファイル名の形式を確認してください。");

            if (wStartDate > DateTime.Today)
                throw new InvalidDataException($"ファイル名({vFileName})から解析された開始日({wStartDate:yyyy/MM/dd})は未来の日付です。ファイル名の形式を確認してください。");

            return wStartDate;
        }

        /// <summary>
        /// 売上データが基準日からの指定期間内に収まっているかを検証
        /// </summary>
        /// <param name="vSales">検証対象の売上データ</param>
        /// <param name="vStartDate">期間の開始日</param>
        public static void EnsureWithinRange(IReadOnlyList<SaleModel> vSales, DateTime vStartDate) {
            if (!vSales.Any()) return;

            var wEndDate = vStartDate.AddDays(C_TargetPeriodDays - 1);

            var wHasInvalidDate = vSales.Any(x => x.FSaleDate < vStartDate || x.FSaleDate > wEndDate);

            if (wHasInvalidDate)
                throw new InvalidDataException($"売上データの中に、期間外の日付が含まれています。データの内容を確認してください。期間は{vStartDate:yyyy/MM/dd}から{wEndDate:yyyy/MM/dd}までです。");
        }
    }
}
