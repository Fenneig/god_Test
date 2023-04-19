using GoTTest.Model.Data.Inventory;
using GoTTest.Model.Definitions;
using GoTTest.Services;
using GoTTest.UI.Item;
using GoTTest.UI.ItemSlot;
using UnityEngine;

namespace GoTTest.Model
{
    public class InventoryModel : MonoBehaviour
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
            var unlockedSlots = (int)
                GameSession.Instance.Data.PurchasesData.GetTotalPurchasedAmount(Idents.ShopDefs.InventorySlots);
            _inventory = new InventorySlotWidget[slots];

            InitInventoryWidgets(slots, blockedSlots - unlockedSlots);
            
            foreach (var item in _sessionInventoryData.GetAll())
            {
                if (item.InventoryIndex != -1) InstantiateItemWidgetAtIndex(item.InventoryIndex);

                Render(item, item.Amount);
            }
            
            UnlockInventorySlots(Idents.ShopDefs.InventorySlots);
            
            _sessionInventoryData.OnInventoryChanged += Render;
            GameSession.ShopModel.OnBuyLot += UnlockInventorySlots;
        }
        
        private void UnlockInventorySlots(string purchaseId)
        {
            if (purchaseId != Idents.ShopDefs.InventorySlots) return;
            
            var sessionPurchasedData = GameSession.Instance.Data.PurchasesData;
            if (!sessionPurchasedData.HasPurchase(purchaseId)) return;
            
            var purchasedSlots = sessionPurchasedData.GetTotalPurchasedAmount(Idents.ShopDefs.InventorySlots);
            var totalSlots = _sessionInventoryData.InventorySize;
            var blockedSlots = _sessionInventoryData.InventoryBlockedSlots;

            var baseUnlockedSlotsIndex = totalSlots - blockedSlots;

            for (int i = baseUnlockedSlotsIndex; i < baseUnlockedSlotsIndex + purchasedSlots; i++)
            {
                if (_inventory[i].IsLocked) _inventory[i].UnlockCell();
            }
        }


        private void InitInventoryWidgets(int slots, int blockedSlots)
        {
            for (int i = 0; i < slots; i++)
            {
                var inventoryCell = Instantiate(_inventorySlotPrefab, _contentContainer);
                _inventory[i] = inventoryCell;
                _inventory[i].SetIndex(i);

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
            
            if (itemWidget == null) return;

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
                if (_inventory[i].ItemWidget == null) return i;
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