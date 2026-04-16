using System.Collections.Generic;
using System.Linq;
using SalesManager.Models;

namespace SalesManager.Services {
    /// <summary>
    /// 各種データを統合し、集計結果を生成するクラス
    /// </summary>
    public class SalesAggregator {
        #region フィールド

        private static readonly int C_RestockThreshold = 5;

        #endregion

        #region publicメソッド

        /// <summary>
        /// 売上データを各種モデルと結合し、集計結果のリストを生成するメソッド
        /// </summary>
        /// <param name="vSales">売上データのリスト</param>
        /// <param name="vStores">店舗データのリスト</param>
        /// <param name="vProducts">商品データのリスト</param>
        /// <param name="vInventories">在庫データのリスト</param>
        /// <returns>集計結果</returns>
        public List<AggregatedSalesModel> Aggregate(
            IReadOnlyList<SaleModel> vSales,
            IReadOnlyList<ProductModel> vProducts,
            IReadOnlyList<InventoryModel> vInventories) {

            var wSalesByProduct = vSales.GroupBy(x => x.ProductId).ToDictionary(y => y.Key, y => y.Sum(x => x.Quantity));

            var wInventoryByProduct = vInventories.GroupBy(x => x.ProductId).ToDictionary(y => y.Key, y => y.Sum(x => x.Stock));

            var wResultList = new List<AggregatedSalesModel>();

            foreach (var wProduct in vProducts) {
                if (!wSalesByProduct.TryGetValue(wProduct.ProductId, out var wTotalSoldQuantity)) continue;

                var wCurrentInventory = wInventoryByProduct.TryGetValue(wProduct.ProductId, out var wStock) ? wStock : 0;

                var wRemainingInventory = wCurrentInventory - wTotalSoldQuantity;
                wResultList.Add(new AggregatedSalesModel {
                    ProductId = wProduct.ProductId,
                    ProductName = wProduct.ProductName,
                    TotalSoldQuantity = wTotalSoldQuantity,
                    CurrentInventory = wCurrentInventory,
                    RemainingInventory = wRemainingInventory,
                    IsRestockNeeded = wRemainingInventory < C_RestockThreshold,
                    TotalSalesAmount = wTotalSoldQuantity * wProduct.UnitPrice
                });
            }

            return wResultList;
        }

        #endregion
    }
}