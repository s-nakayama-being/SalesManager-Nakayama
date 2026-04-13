using System.Collections.Generic;
using System.Linq;
using SalesManager.Models;

namespace SalesManager.Business {
    /// <summary>
    /// 各種データを統合し、集計結果を生成するクラス
    /// </summary>
    public class SalesAggregator {

        private readonly int FRestockThreshold = 5;

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

            var wStoreDict = vStores.ToDictionary(x => x.FStoreId);
            var wProductDict = vProducts.ToDictionary(x => x.FProductId);
            var wInventoryDict = vInventories.ToDictionary(x => (x.FStoreId, x.FProductId));

            var wResultList = new List<AggregatedSalesDto>();

            var wGroupedSales = vSales
                .GroupBy(x => (x.FStoreId, x.FProductId))
                .Select(y => (
                    y.Key.FStoreId,
                    y.Key.FProductId,
                    y.Sum(x => x.FQuantity)
                ));

            foreach (var wSale in wGroupedSales) {
                if (!TryGetMasterData(wSale, wStoreDict, wProductDict, wInventoryDict, out var wLinkedData)) continue;

                wResultList.Add(CreateDto(wSale, wLinkedData));
            }

            return wResultList;
        }

        private bool TryGetMasterData(
            (int FStoreId, int FProductId, int FTotalQuantity) vSale,
            Dictionary<int, StoreModel> vStoreDict,
            Dictionary<int, ProductModel> vProductDict,
            Dictionary<(int, int), InventoryModel> vInventoryDict,
            out (StoreModel Store, ProductModel Product, InventoryModel Inventory) vData) {

            if (vStoreDict.TryGetValue(vSale.FStoreId, out var wStore) &&
                vProductDict.TryGetValue(vSale.FProductId, out var wProduct) &&
                vInventoryDict.TryGetValue((vSale.FStoreId, vSale.FProductId), out var wInventory)) {

                vData = (wStore, wProduct, wInventory);
                return true;
            }

            vData = default;
            return false;
        }

        private AggregatedSalesDto CreateDto(
            (int FStoreId, int FProductId, int FTotalQuantity) vSale,
            (StoreModel Store, ProductModel Product, InventoryModel Inventory) vLinkedData) {

            var wRemaining = vLinkedData.Inventory.FStock - vSale.FTotalQuantity;

            return new AggregatedSalesDto {
                FStoreName = vLinkedData.Store.FStoreName,
                FProductName = vLinkedData.Product.FProductName,
                FTotalSoldQuantity = vSale.FTotalQuantity,
                FTotalSalesAmount = (decimal)(vSale.FTotalQuantity * vLinkedData.Product.FUnitPrice),
                FRemainingInventory = wRemaining,
                FIsRestockNeeded = wRemaining <= FRestockThreshold
            };
        }
    }
}