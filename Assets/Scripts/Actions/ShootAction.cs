using GoTTest.Model;
using GoTTest.Model.Definitions.Items;
using GoTTest.Services;
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
                if (randomAmmo == null) Debug.LogError(Idents.Errors.OutOfAmmo);
                else GameSession.Instance.Data.InventoryData.RemoveItem(randomAmmo.Id, 1);
            }
            else
            {
                Debug.LogError(Idents.Errors.OutOfAmmo);
            }
        }
        
    }
}