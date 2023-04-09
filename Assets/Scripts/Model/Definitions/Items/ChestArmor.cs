using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    [CreateAssetMenu(fileName = "ChestArmor", menuName = "Defs/Items/ChestArmor")]
    public class ChestArmor : ItemDef
    {
        [SerializeField] private int _armor;

        public int Armor => _armor;

        private void Awake()
        {
            ItemType = ItemType.ChestArmor;
        }
    }
}