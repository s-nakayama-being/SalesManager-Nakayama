namespace SalesManager.Models {
    /// <summary>
    /// 売上データを集計して保持するクラス
    /// </summary>
    public class AggregatedSalesDto {
        /// <summary>
        /// 店舗名
        /// </summary>
        public string FStoreName { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string FProductName { get; set; }

        /// <summary>
        /// 合計売上数量
        /// </summary>
        public int FTotalSoldQuantity { get; set; }

        /// <summary>
        /// 合計売上金額
        /// </summary>
        public decimal FTotalSalesAmount { get; set; }

        /// <summary>
        /// 販売後在庫数量
        /// </summary>
        public int FRemainingInventory { get; set; }

        /// <summary>
        /// 発注要否
        /// </summary>
        public bool FIsRestockNeeded { get; set; }
    }
}