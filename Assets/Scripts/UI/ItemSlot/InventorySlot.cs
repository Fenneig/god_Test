using GoTTest.Model;
using GoTTest.Model.Data.Inventory;
using GoTTest.UI.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GoTTest.UI.ItemSlot
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private InventorySlotWidget _widget;

        public void OnDrop(PointerEventData eventData)
        {
            if (_widget.ItemWidget != null || _widget.IsLocked) return;
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            
            if (draggableItem == null) return;
            draggableItem.OriginParentTransform = transform;
            var originIndex = draggableItem.OriginInventorySlot.Index;
            var moveToIndex = _widget.Index;
            var item = GameSession.Instance.Data.InventoryData.GetItemAtIndex(originIndex);
            var itemAtNewIndex = new ItemData(item.Id) {Amount = item.Amount, InventoryIndex = moveToIndex};

            _widget.SetItemWidget(draggableItem.ItemWidget);
            GameSession.Instance.Data.InventoryData.AddItem(itemAtNewIndex);

            draggableItem.OriginInventorySlot.ReleaseItem();
            GameSession.Instance.Data.InventoryData.RemoveAtIndex(originIndex);
        }
    }
}