using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    [CreateAssetMenu(fileName = "HeadArmor", menuName = "Defs/ItemsDef/HeadArmor")]
    public class HeadArmor : ItemDef
    {
        public int Armor;
        
        private void Awake()
        {
            ItemType = ItemType.HeadArmor;
        }
    }
}