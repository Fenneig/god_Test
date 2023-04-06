using GoTTest.Model;
using GoTTest.UI;
using UnityEngine;

namespace GoTTest
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryCellWidget _inventoryCell;
        [SerializeField] private Transform _contentContainer;
        

        private void Start()
        {
            var slots = GameSession.Instance.Data.InventoryData.InventorySize;
            var blockedSlots = GameSession.Instance.Data.InventoryData.InventoryBlockedSlots;
            
            for (int i = 0; i < slots; i++)
            {
                var inventoryCell = Instantiate(_inventoryCell, _contentContainer);
                
                inventoryCell.UnlockCell();
                if (i < blockedSlots) inventoryCell.LockCell();
            }
        }
    }
}