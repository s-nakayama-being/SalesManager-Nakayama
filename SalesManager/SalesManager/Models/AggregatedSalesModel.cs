using CsvHelper.Configuration.Attributes;
using System.ComponentModel;

namespace SalesManager.Models {
    /// <summary>
    /// 売上データを集計して保持するクラス
    /// </summary>
    public class AggregatedSalesModel {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 合計売上数量
        /// </summary>
        public int TotalSoldQuantity { get; set; }

        /// <summary>
        /// 現在の在庫数量
        /// </summary>
        public int CurrentInventory { get; set; }

        /// <summary>
        /// 販売後在庫数量
        /// </summary>
        public int RemainingInventory { get; set; }

        /// <summary>
        /// 発注要否
        /// </summary>
        [Browsable(false)]
        [Ignore]
        public bool IsRestockNeeded { get; set; }

        /// <summary>
        /// 発注要否の表示用
        /// </summary>
        public string RestockStatus => IsRestockNeeded ? "要発注" : "";

        /// <summary>
        /// 合計売上金額
        /// </summary>
        public decimal TotalSalesAmount { get; set; }
    }
}