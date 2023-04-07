using GoTTest.Model;
using GoTTest.Model.Data;
using GoTTest.Model.Definitions;
using GoTTest.Services;
using GoTTest.UI;
using UnityEngine;

namespace GoTTest
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventorySlotWidget _inventorySlotPrefab;
        [SerializeField] private ItemWidget _itemPrefab;
        [SerializeField] private Transform _contentContainer;

        private InventorySlotWidget[] _inventory;
        private InventoryData _sessionInventoryData;

        private void Start()
        {
            _sessionInventoryData = GameSession.Instance.Data.InventoryData;

            var slots = _sessionInventoryData.InventorySize;
            var blockedSlots = _sessionInventoryData.InventoryBlockedSlots;
            _inventory = new InventorySlotWidget[slots];

            for (int i = 0; i < slots; i++)
            {
                var inventoryCell = Instantiate(_inventorySlotPrefab, _contentContainer);
                _inventory[i] = inventoryCell;

                inventoryCell.UnlockCell();
                if (slots - i <= blockedSlots) inventoryCell.LockCell();
            }

            _sessionInventoryData.OnInventoryChanged += Render;

            foreach (var item in _sessionInventoryData.GetAll())
            {
                if (item.InventoryIndex != -1) InstantiateItemWidgetAtIndex(item.InventoryIndex);

                Render(item, item.Amount);
            }
        }

        private void Render(ItemData item, int amount)
        {
            var itemDef = DefsFacade.I.ItemsRepository.Get(item.Id);

            ItemWidget itemWidget;

            if (item.InventoryIndex == -1)
            {
                var index = FindFirstFreeSlot();
                item.InventoryIndex = index;
                
                InstantiateItemWidgetAtIndex(index);
            }

            itemWidget = _inventory[item.InventoryIndex].ItemWidget;

            if (amount == 0) _inventory[item.InventoryIndex].ReleaseItem();


            itemWidget.SetData(itemDef, amount);
        }

        private void InstantiateItemWidgetAtIndex(int index)
        {
            ItemWidget itemWidget;
            itemWidget = Instantiate(_itemPrefab, _inventory[index].transform);
            _inventory[index].SetItemWidget(itemWidget);
        }

        private int FindFirstFreeSlot()
        {
            for (int i = 0; i < _inventory.Length; i++)
            {
                if (_inventory[i].IsFree) return i;
            }

            Debug.LogError(Idents.Errors.LogicErrorFullInventory);
            return -1;
        }

        private void OnDestroy()
        {
            _sessionInventoryData.OnInventoryChanged -= Render;
        }
    }
}