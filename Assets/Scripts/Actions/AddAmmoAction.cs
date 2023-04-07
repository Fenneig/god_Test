using GoTTest.Model;
using GoTTest.Model.Definitions;
using GoTTest.Model.Definitions.Items;
using UnityEngine;

namespace GoTTest.Actions
{
    public class AddAmmoAction : MonoBehaviour
    {
        public void AddAmmo()
        {
            var items = DefsFacade.I.ItemsDef.GetItemsByType(ItemType.Consumable);
            
            foreach (var item in items)
                GameSession.Instance.Data.InventoryData.Add(item.Id, item.MaxStackSize);
        }
    }
}
