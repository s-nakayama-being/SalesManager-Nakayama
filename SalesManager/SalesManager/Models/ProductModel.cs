namespace SalesManager.Models {
    /// <summary>
    /// 商品マスタデータを保持するクラス
    /// </summary>
    public class ProductModel {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int FProductId { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string FProductName { get; set; }

        /// <summary>
        /// 単価
        /// </summary>
        public decimal FUnitPrice { get; set; }

        /// <summary>
        /// カテゴリー
        /// </summary>
        public string FCategory { get; set; }
    }
}