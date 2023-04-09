using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Defs/Items/Weapon")]
    public class Weapon : ItemDef
    {
        [SerializeField] private int _damage;

        public int Damage => _damage;

        private void Awake()
        {
            ItemType = ItemType.Weapon;
        }
    }
}