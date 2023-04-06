using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Defs/Items/Weapon")]
    public class Weapon : ItemDef
    {
        public int Damage;
        
        private void Awake()
        {
            ItemType = ItemType.Weapon;
        }
    }
}