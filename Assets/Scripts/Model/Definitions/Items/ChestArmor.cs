using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    [CreateAssetMenu(fileName = "ChestArmor", menuName = "Defs/ItemsDef/ChestArmor")]
    public class ChestArmor : ItemDef
    {
        public int Armor;

        private void Awake()
        {
            ItemType = ItemType.ChestArmor;
        }
    }
}