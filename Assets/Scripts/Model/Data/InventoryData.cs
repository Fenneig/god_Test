using System;
using System.Collections.Generic;
using System.Linq;
using GoTTest.Model.Definitions;
using GoTTest.Model.Definitions.Items;
using GoTTest.Services;
using UnityEngine;

namespace GoTTest.Model.Data
{
    [Serializable]
    public class InventoryData
    {
        [SerializeField] private int _inventorySize;
        [SerializeField] private int _inventoryBlockedSlots;
        [SerializeField] private List<ItemData> _itemsData;

        public int InventorySize => _inventorySize;
        public int InventoryBlockedSlots => _inventoryBlockedSlots;

        public event Action<ItemData, int> OnInventoryChanged;

        public void Add(string id, int value)
        {
            if (value <= 0) return;

            var valueLeft = value;
            var itemDef = DefsFacade.I.ItemsDef.Get(id);
            var items = GetItems(id);

            foreach (var item in items)
            {
                if (valueLeft == 0) break;

                if (item.Amount == itemDef.MaxStackSize) continue;

                if (valueLeft + item.Amount >= itemDef.MaxStackSize)
                {
                    valueLeft -= itemDef.MaxStackSize - item.Amount;
                    item.Amount = itemDef.MaxStackSize;
                }
                else
                {
                    item.Amount += valueLeft;
                    valueLeft = 0;
                }
                
                OnInventoryChanged?.Invoke(item, item.Amount);
            }

            while (valueLeft != 0)
            {
                if (!IsThereFreeSlots())
                {
                    Debug.LogError(Idents.Errors.FullInventory);
                    break;
                }
                var item = new ItemData(id) { Amount = Mathf.Min(valueLeft, itemDef.MaxStackSize) };

                _itemsData.Add(item);

                valueLeft -= item.Amount;
                
                OnInventoryChanged?.Invoke(item, item.Amount);
            }
        }

        private bool IsThereFreeSlots()
        {
            var slotsOccupiedAmount = GetAll().Length;

            return slotsOccupiedAmount < _inventorySize - _inventoryBlockedSlots;
        }

        public void RemoveItem(string id, int value)
        {
            var item = GetItem(id);
            if (item == null)
            {
                Debug.LogError($"{Idents.Errors.InventoryNotContain} {id}");
                return;
            }

            item.Amount -= value;

            if (item.Amount <= 0)
                _itemsData.Remove(item);

            OnInventoryChanged?.Invoke(item, item.Amount);
        }

        public void RemoveAtIndex(int index)
        {
            var item = _itemsData.FirstOrDefault(item => item.InventoryIndex == index);

            if (item == null)
            {
                Debug.LogError($"{Idents.Errors.NoItemAtIndex} {index}");
                return;
            }
            
            item.Amount -= item.Amount;
            _itemsData.Remove(item);

            OnInventoryChanged?.Invoke(item, 0);
        }

        private ItemData GetItem(string id) =>
            _itemsData.FirstOrDefault(itemData => itemData.Id == id);

        private List<ItemData> GetItems(string id) =>
            _itemsData.Where(itemData => itemData.Id == id).ToList();


        public ItemData[] GetAll() =>
            _itemsData.ToArray();

        public bool TryGetAllItemsOfType(ItemType type, out List<ItemData> items)
        {
            items = new List<ItemData>();
            foreach (var itemData in _itemsData)
            {
                if (DefsFacade.I.ItemsDef.Get(itemData.Id).ItemType == type)
                    items.Add(itemData);
            }

            return items.Count > 0;
        }
    }
}