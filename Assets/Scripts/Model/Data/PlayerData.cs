using System;
using GoTTest.Model.Data.Inventory;
using GoTTest.Model.Data.Purchases;
using UnityEngine;

namespace GoTTest.Model.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private InventoryData _inventory;
        [SerializeField] private PurchaseData _purchasesData;

        public InventoryData InventoryData => _inventory;
        public PurchaseData PurchasesData => _purchasesData;

    }

    
}