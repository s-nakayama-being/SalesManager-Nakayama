namespace SalesManager.Models {
    /// <summary>
    /// 商品マスタデータを保持するクラス
    /// </summary>
    public class ProductModel {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 単価
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// カテゴリー
        /// </summary>
        public string Category { get; set; }
    }
}