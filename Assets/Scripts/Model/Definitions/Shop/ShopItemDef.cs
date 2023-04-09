using GoTTest.Services;
using UnityEngine;

namespace GoTTest.Model.Definitions.Shop
{
    public class ShopItemDef : ScriptableObject, IHaveId
    {
        [SerializeField] private string _id;
        public string Id => _id;
    }
}