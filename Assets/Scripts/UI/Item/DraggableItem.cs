using GoTTest.UI.ItemSlot;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GoTTest.UI.Item
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private ItemWidget _itemWidget;
        
        public Transform OriginParentTransform { get; set; }
        public InventorySlotWidget OriginInventorySlot { get; private set; }

        public ItemWidget ItemWidget => _itemWidget;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            OriginParentTransform = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            _image.raycastTarget = false;
            OriginInventorySlot = OriginParentTransform.GetComponent<InventorySlotWidget>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(OriginParentTransform);
            _image.raycastTarget = true;
            SnapItem();
        }

        private void SnapItem()
        {
            var originPivot = _rectTransform.pivot;
            _rectTransform.pivot = Vector2.zero;
            transform.localPosition = Vector3.zero;
            _rectTransform.pivot = originPivot;
        }
    }
}
