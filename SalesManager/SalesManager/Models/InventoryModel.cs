namespace SalesManager.Models {
    /// <summary>
    /// 在庫データを保持するクラス
    /// </summary>
    public class InventoryModel {
        /// <summary>
        /// 店舗ID
        /// </summary>
        public int FStoreId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int FProductId { get; set; }

        /// <summary>
        /// 在庫数量
        /// </summary>
        public int FStock { get; set; }
    }
}