using GoTTest.Model;
using GoTTest.Model.Definitions;
using GoTTest.Model.Definitions.Items;
using UnityEngine;

namespace GoTTest.Actions
{
    public class AddItemsAction : MonoBehaviour
    {
        public void AddItems()
        {
            var weapons = DefsFacade.I.ItemsRepository.GetItemsByType(ItemType.Weapon);
            var randomWeapon = PickRandomItemFromArray(weapons);
            GameSession.Instance.Data.InventoryData.Add(randomWeapon.Id, 1);
            
            var headArmor = DefsFacade.I.ItemsRepository.GetItemsByType(ItemType.HeadArmor);
            var randomHeadArmor = PickRandomItemFromArray(headArmor);
            GameSession.Instance.Data.InventoryData.Add(randomHeadArmor.Id, 1);
            
            var chestArmor = DefsFacade.I.ItemsRepository.GetItemsByType(ItemType.ChestArmor);
            var randomChestArmor = PickRandomItemFromArray(chestArmor);
            GameSession.Instance.Data.InventoryData.Add(randomChestArmor.Id, 1);
        }

        private ItemDef PickRandomItemFromArray(ItemDef[] array)
        {
            var randomNum = Random.Range(0, array.Length);
            return array[randomNum];
        }
    }
}