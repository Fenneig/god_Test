using UnityEngine;
using UnityEngine.UI;

namespace GoTTest.UI
{
    public class InventoryCellWidget : MonoBehaviour
    {
        [SerializeField] private Image _blockedCell;

        public void LockCell() =>
            _blockedCell.gameObject.SetActive(false);

        public void UnlockCell() => 
            _blockedCell.gameObject.SetActive(true);
    }
}