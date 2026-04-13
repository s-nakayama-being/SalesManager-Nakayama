namespace SalesManager.Models {
    /// <summary>
    /// 在庫データを保持するクラス
    /// </summary>
    public class InventoryModel {
        /// <summary>
        /// 店舗ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 在庫数量
        /// </summary>
        public int Stock { get; set; }
    }
}