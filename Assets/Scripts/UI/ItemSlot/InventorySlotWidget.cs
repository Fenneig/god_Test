using GoTTest.UI.Item;
using UnityEngine;
using UnityEngine.UI;

namespace GoTTest.UI.ItemSlot
{
    public class InventorySlotWidget : MonoBehaviour
    {
        [SerializeField] private Image _blockedCell;
        
        public int Index { get; private set; }
        
        public ItemWidget ItemWidget { get; private set; }

        public bool IsLocked { get; set; }

        public void SetItemWidget(ItemWidget item)
        {
            ItemWidget = item;
        }

        public void SetIndex(int index)
        {
            Index = index;
        }

        public void ReleaseItem()
        {
            ItemWidget = null;
        }

        public void LockCell()
        {
            IsLocked = true;
            _blockedCell.gameObject.SetActive(true);
        }

        public void UnlockCell()
        {
            IsLocked = false;
            _blockedCell.gameObject.SetActive(false);
        }
    }
}