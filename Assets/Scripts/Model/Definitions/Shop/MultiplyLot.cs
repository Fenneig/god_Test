using UnityEngine;

namespace GoTTest.Model.Definitions.Shop
{
    [CreateAssetMenu(fileName = "MultiplyLot", menuName = "Defs/Shop/MultiplyLot")]
    public class MultiplyLot : ShopItemDef
    {
        [SerializeField] private LotDef[] _levels;

        public LotDef[] Levels => _levels;
    }
}