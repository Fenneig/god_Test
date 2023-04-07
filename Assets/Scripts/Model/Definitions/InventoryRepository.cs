using System.Linq;
using GoTTest.Model.Definitions.Items;
using UnityEngine;

namespace GoTTest.Model.Definitions
{
    [CreateAssetMenu(fileName = "InventoryRepository", menuName = "Defs/InventoryRepository")]
    public class InventoryRepository : ScriptableObject
    {
        [SerializeField] private ItemDef[] _items;

        public ItemDef Get(string id) =>
            _items.FirstOrDefault(item => item.Id == id);

        public ItemDef[] GetItemsByType(ItemType type) => 
            _items.Where(item => item.ItemType == type).ToArray();
    }
}