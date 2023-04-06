using System;
using UnityEngine;

namespace GoTTest.Model.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private InventoryData _inventory;

        public InventoryData InventoryData => _inventory;
    }
}