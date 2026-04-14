using System.Collections.Generic;
using System.Linq;
using SalesManager.Models;

namespace SalesManager.Services {
    /// <summary>
    /// 各種データを統合し、集計結果を生成するクラス
    /// </summary>
    public class SalesAggregator {
        private static readonly int C_RestockThreshold = 5;

        /// <summary>
        /// 売上データを各種モデルと結合し、集計結果のDTOリストを生成するメソッド
        /// </summary>
        /// <param name="vSales">売上データのリスト</param>
        /// <param name="vStores">店舗データのリスト</param>
        /// <param name="vProducts">商品データのリスト</param>
        /// <param name="vInventories">在庫データのリスト</param>
        /// <returns>集計結果</returns>
        public List<AggregatedSalesDto> Aggregate(
            IReadOnlyList<SaleModel> vSales,
            IReadOnlyList<StoreModel> vStores,
            IReadOnlyList<ProductModel> vProducts,
            IReadOnlyList<InventoryModel> vInventories) {

            var wStoreDict = vStores.ToDictionary(x => x.StoreId);
            var wProductDict = vProducts.ToDictionary(x => x.ProductId);
            var wInventoryDict = vInventories.ToDictionary(x => (x.StoreId, x.ProductId));

            var wResultList = new List<AggregatedSalesDto>();

            var wGroupedSales = vSales
                .GroupBy(x => (x.StoreId, x.ProductId))
                .Select(y => (
                    y.Key.StoreId,
                    y.Key.ProductId,
                    TotalQuantity: y.Sum(x => x.Quantity)
                ));

            foreach (var wSale in wGroupedSales) {
                if (!TryGetMasterData(wSale, wStoreDict, wProductDict, wInventoryDict, out var wLinkedData)) continue;

                wResultList.Add(CreateDto(wSale, wLinkedData));
            }

            return wResultList;
        }

        private bool TryGetMasterData(
            (int StoreId, int ProductId, int TotalQuantity) vSale,
            Dictionary<int, StoreModel> vStoreDict,
            Dictionary<int, ProductModel> vProductDict,
            Dictionary<(int, int), InventoryModel> vInventoryDict,
            out (StoreModel Store, ProductModel Product, InventoryModel Inventory) vData) {

            if (vStoreDict.TryGetValue(vSale.StoreId, out var wStore) &&
                vProductDict.TryGetValue(vSale.ProductId, out var wProduct) &&
                vInventoryDict.TryGetValue((vSale.StoreId, vSale.ProductId), out var wInventory)) {

                vData = (wStore, wProduct, wInventory);
                return true;
            }

            vData = default;
            return false;
        }

        private AggregatedSalesDto CreateDto(
            (int StoreId, int ProductId, int TotalQuantity) vSale,
            (StoreModel Store, ProductModel Product, InventoryModel Inventory) vLinkedData) {

            var wRemaining = vLinkedData.Inventory.Stock - vSale.TotalQuantity;

            return new AggregatedSalesDto {
                ProductId = vSale.ProductId,
                ProductName = vLinkedData.Product.ProductName,
                TotalSoldQuantity = vSale.TotalQuantity,
                CurrentInventory = vLinkedData.Inventory.Stock,
                RemainingInventory = wRemaining,
                IsRestockNeeded = wRemaining <= C_RestockThreshold,
                TotalSalesAmount = vSale.TotalQuantity * vLinkedData.Product.UnitPrice,

            };
        }
    }
}