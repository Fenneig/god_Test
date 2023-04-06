using GoTTest.Model;
using GoTTest.Model.Definitions.Items;
using UnityEngine;

namespace GoTTest.Actions
{
    public class ShootAction : MonoBehaviour
    {
        public void Shoot()
        {
            if (GameSession.Instance.Data.InventoryData.TryGetAllItemsOfType(ItemType.Consumable, out var consumablesArray))
            {
                var randomAmmo = consumablesArray[Random.Range(0, consumablesArray.Count)];
                GameSession.Instance.Data.InventoryData.Remove(randomAmmo.Id, 1);
            }
        }
        
    }
}