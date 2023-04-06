using System;
using System.Collections.Generic;
using System.Linq;
using GoTTest.Model.Definitions;
using GoTTest.Services;
using UnityEngine;

namespace GoTTest.Model.Data
{
    [Serializable]
    public class InventoryData
    {
        [SerializeField] private int _inventorySize;
        [SerializeField] private int _inventoryBlockedSlots;
        [SerializeField] private List<ItemData> _itemData;

        public int InventorySize => _inventorySize;
        public int InventoryBlockedSlots => _inventoryBlockedSlots;

        public event Action OnInventoryChanged;

        public void Add(string id, int value)
        {
            if (value <= 0) return;

            var valueLeft = value;
            var itemDef = DefsFacade.I.Items.Get(id);
            var items = GetItems(id);

            foreach (var item in items)
            {
                if (valueLeft == 0) break;

                if (item.Value == itemDef.MaxStackSize) continue;

                if (valueLeft + item.Value >= itemDef.MaxStackSize)
                {
                    valueLeft -= itemDef.MaxStackSize - item.Value;
                    item.Value = itemDef.MaxStackSize;
                }
                else
                {
                    item.Value += valueLeft;
                    valueLeft = 0;
                }
            }

            while (valueLeft != 0)
            {
                if (!IsThereFreeSlots())
                {
                    Debug.LogError(Idents.Errors.FullInventory);
                    break;
                }
                var item = new ItemData(id) { Value = Mathf.Min(valueLeft, itemDef.MaxStackSize) };

                _itemData.Add(item);

                valueLeft -= item.Value;
            }

            OnInventoryChanged?.Invoke();
        }

        private bool IsThereFreeSlots()
        {
            var slotsOccupiedAmount = GetAll().Length;

            return slotsOccupiedAmount < _inventorySize - _inventoryBlockedSlots;
        }

        public void Remove(string id, int value)
        {
            var item = GetItem(id);
            if (item == null) return;

            item.Value -= value;

            if (item.Value <= 0)
                _itemData.Remove(item);

            OnInventoryChanged?.Invoke();
        }

        private ItemData GetItem(string id) =>
            _itemData.FirstOrDefault(itemData => itemData.Id == id);

        private List<ItemData> GetItems(string id) =>
            _itemData.Where(itemData => itemData.Id == id).ToList();


        public ItemData[] GetAll() =>
            _itemData.ToArray();
    }
}