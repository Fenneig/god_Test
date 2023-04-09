using GoTTest.Model.Definitions.Repositories;
using UnityEngine;

namespace GoTTest.Model.Definitions
{
    [CreateAssetMenu(fileName = "DefsFacade", menuName = "Defs/DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private InventoryRepository _itemsItemsRepository;
        [SerializeField] private ShopRepository _shopRepository;

        public InventoryRepository ItemsRepository => _itemsItemsRepository;
        public ShopRepository ShopRepository => _shopRepository;
        
        private static DefsFacade _instance;
        public static DefsFacade I => _instance == null ? LoadDefs() : _instance;

        private static DefsFacade LoadDefs() => 
            _instance = Resources.Load<DefsFacade>("DefsFacade");
    }
}