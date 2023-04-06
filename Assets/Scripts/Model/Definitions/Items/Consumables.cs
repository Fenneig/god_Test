using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    [CreateAssetMenu(fileName = "Consumable", menuName = "Defs/Items/Consumable")]
    public class Consumables : ItemDef
    {
        private void Awake()
        {
            ItemType = ItemType.Consumable;
        }
    }
}