using UnityEngine;
using UnityEngine.UI;

namespace GoTTest.UI
{
    public class InventorySlotWidget : MonoBehaviour
    {
        [SerializeField] private Image _blockedCell;
        public ItemWidget ItemWidget { get; private set; }

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
        
        public bool IsFree { get; set; }

        public void LockCell()
        {
            IsFree = false;
            _blockedCell.gameObject.SetActive(true);
        }

        public void UnlockCell()
        {
            IsFree = true;
            _blockedCell.gameObject.SetActive(false);
        }
    }
}