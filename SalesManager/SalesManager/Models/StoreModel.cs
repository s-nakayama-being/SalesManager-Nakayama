namespace SalesManager.Models {
    /// <summary>
    /// 店舗マスタデータを保持するクラス
    /// </summary>
    public class StoreModel {
        /// <summary>
        /// 店舗ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 店舗名
        /// </summary>
        public string StoreName { get; set; }
    }
}