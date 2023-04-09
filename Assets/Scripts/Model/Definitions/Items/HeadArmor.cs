using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    [CreateAssetMenu(fileName = "HeadArmor", menuName = "Defs/Items/HeadArmor")]
    public class HeadArmor : ItemDef
    {
        [SerializeField] private int _armor;

        public int Armor => _armor;

        private void Awake()
        {
            ItemType = ItemType.HeadArmor;
        }
    }
}