using UnityEngine;
using UnityEngine.UI;

namespace GoTTest.UI
{
    public class InventorySlotWidget : MonoBehaviour
    {
        [SerializeField] private Image _blockedCell;
        public ItemWidget ItemWidget { get; private set; }

        public bool IsFree { get; set; }
        public bool IsLocked { get; set; }

        public void SetItemWidget(ItemWidget item)
        {
            ItemWidget = item;
            IsFree = false;
        }

        public void ReleaseItem()
        {
            ItemWidget = null;
            IsFree = true;
        }

        public void LockCell()
        {
            IsFree = false;
            IsLocked = true;
            _blockedCell.gameObject.SetActive(true);
        }

        public void UnlockCell()
        {
            IsFree = true;
            IsLocked = false;
            _blockedCell.gameObject.SetActive(false);
        }
    }
}