using System.Linq;
using GoTTest.Model.Definitions.Items;
using UnityEngine;

namespace GoTTest.Model.Definitions.Repositories
{
    [CreateAssetMenu(fileName = "InventoryRepository", menuName = "Defs/Repositories/InventoryWidget")]
    public class InventoryRepository : DefRepository<ItemDef>
    {
        public ItemDef[] GetItemsByType(ItemType type) => 
            _collection.Where(item => item.ItemType == type).ToArray();
    }
}