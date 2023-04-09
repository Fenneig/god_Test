using UnityEngine;

namespace GoTTest.Model.Definitions.Shop
{
    [CreateAssetMenu(fileName = "SingleLot", menuName = "Defs/Shop/SingleLot")]

    public class SingleLot : ShopItemDef
    {
        [SerializeField] private LotDef _lot;
        
        public LotDef Lot => _lot;
    }
}