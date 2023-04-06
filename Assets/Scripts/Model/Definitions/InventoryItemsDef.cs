using System.Linq;
using GoTTest.Model.Definitions.Items;
using UnityEngine;

namespace GoTTest.Model.Definitions
{
    [CreateAssetMenu(fileName = "InventoryDef", menuName = "Defs/InventoryItem")]
    public class InventoryItemsDef : ScriptableObject
    {
        [SerializeField] private ItemDef[] _items;

        public ItemDef Get(string id) =>
            _items.FirstOrDefault(item => item.Id == id);
    }
}