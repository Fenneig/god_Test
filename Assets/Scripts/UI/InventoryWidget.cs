using GoTTest.Model;
using GoTTest.Model.Data.Inventory;
using GoTTest.Model.Data.Purchases;
using GoTTest.Model.Definitions;
using GoTTest.Model.Definitions.Shop;
using GoTTest.Services;
using UnityEngine;

namespace GoTTest.UI
{
    public class InventoryWidget : MonoBehaviour
    {
        [SerializeField] private InventorySlotWidget _inventorySlotPrefab;
        [SerializeField] private ItemWidget _itemPrefab;
        [SerializeField] private Transform _contentContainer;

        private InventorySlotWidget[] _inventory;
        private InventoryData _sessionInventoryData;
        private PurchaseData _sessionPurchaseData;

        private void Start()
        {
            _sessionInventoryData = GameSession.Instance.Data.InventoryData;
            
            var slots = _sessionInventoryData.InventorySize;
            var blockedSlots = _sessionInventoryData.InventoryBlockedSlots;
            _inventory = new InventorySlotWidget[slots];

            InitInventoryWidgets(slots, blockedSlots);

            _sessionInventoryData.OnInventoryChanged += Render;
            GameSession.ShopModel.OnBuyLot += UnlockInventorySlots;

            foreach (var item in _sessionInventoryData.GetAll())
            {
                if (item.InventoryIndex != -1) InstantiateItemWidgetAtIndex(item.InventoryIndex);

                Render(item, item.Amount);
            }
        }
        
        private void UnlockInventorySlots(string id)
        {
            if (id != Idents.ShopDefs.InventorySlots) return;
            
            var totalSlots = _sessionInventoryData.InventorySize;
            var blockedSlots = _sessionInventoryData.InventoryBlockedSlots;
            
            var purchaseProgress = GameSession.Instance.Data.PurchasesData.GetPurchaseState(Idents.ShopDefs.InventorySlots);
            var slotsLot = DefsFacade.I.ShopRepository.Get(Idents.ShopDefs.InventorySlots) as MultiplyLot;
            var slotsUnlocked = slotsLot == null ? 0 : slotsLot.Levels[purchaseProgress].Value;
            
            var lastBlockedSlot = totalSlots - blockedSlots;

            for (int i = lastBlockedSlot; i < lastBlockedSlot + slotsUnlocked; i++)
            {
                _inventory[i].UnlockCell();
            }

            GameSession.Instance.Data.InventoryData.UnlockInventorySlots((int) slotsUnlocked);
        }


        private void InitInventoryWidgets(int slots, int blockedSlots)
        {
            for (int i = 0; i < slots; i++)
            {
                var inventoryCell = Instantiate(_inventorySlotPrefab, _contentContainer);
                _inventory[i] = inventoryCell;

                inventoryCell.UnlockCell();
                if (slots - i <= blockedSlots) inventoryCell.LockCell();
            }
        }

        private void Render(ItemData item, int amount)
        {
            var itemDef = DefsFacade.I.ItemsRepository.Get(item.Id);

            if (item.InventoryIndex == -1)
            {
                var index = FindFirstFreeSlot();
                item.InventoryIndex = index;
                
                InstantiateItemWidgetAtIndex(index);
            }

            var itemWidget = _inventory[item.InventoryIndex].ItemWidget;

            if (amount == 0) _inventory[item.InventoryIndex].ReleaseItem();


            itemWidget.SetData(itemDef, amount);
        }

        private void InstantiateItemWidgetAtIndex(int index)
        {
            var itemWidget = Instantiate(_itemPrefab, _inventory[index].transform);
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
            GameSession.ShopModel.OnBuyLot -= UnlockInventorySlots;
        }
    }
}