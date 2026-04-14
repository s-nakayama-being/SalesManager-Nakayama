using System;

namespace SalesManager.Models {
    /// <summary>
    /// 売上データを保持するクラス
    /// </summary>
    public class SaleModel {
        /// <summary>
        /// 売上日
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// 店舗ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 売上数量
        /// </summary>
        public int Quantity { get; set; }
    }
}