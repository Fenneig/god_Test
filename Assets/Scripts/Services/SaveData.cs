using System;
using GoTTest.Model.Data.Inventory;
using GoTTest.Model.Data.Purchases;

namespace GoTTest.Services
{
    [Serializable]
    public class SaveData
    {
        public ItemData[] InventoryData;
        public PurchaseProgress[] PurchasesData;
    }
}