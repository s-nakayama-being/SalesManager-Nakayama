namespace SalesManager.Models {
    /// <summary>
    /// 売上データを集計して保持するクラス
    /// </summary>
    public class AggregatedSalesDto {
        /// <summary>
        /// 店舗名
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 合計売上数量
        /// </summary>
        public int TotalSoldQuantity { get; set; }

        /// <summary>
        /// 合計売上金額
        /// </summary>
        public decimal TotalSalesAmount { get; set; }

        /// <summary>
        /// 販売後在庫数量
        /// </summary>
        public int RemainingInventory { get; set; }

        /// <summary>
        /// 発注要否
        /// </summary>
        public bool IsRestockNeeded { get; set; }
    }
}