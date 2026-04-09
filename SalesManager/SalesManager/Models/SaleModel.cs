using System;

namespace SalesManager.Models {
    /// <summary>
    /// 売上データを保持するクラス
    /// </summary>
    public class SaleModel {
        /// <summary>
        /// 売上日
        /// </summary>
        public DateTime FSaleDate { get; set; }

        /// <summary>
        /// 店舗ID
        /// </summary>
        public int FStoreId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int FProductId { get; set; }

        /// <summary>
        /// 売上数量
        /// </summary>
        public int FQuantity { get; set; }
    }
}