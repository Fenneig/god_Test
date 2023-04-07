using UnityEngine;

namespace GoTTest.Model.Definitions
{
    [CreateAssetMenu(fileName = "DefsFacade", menuName = "Defs/DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private InventoryItemsDef _itemsDef;

        public InventoryItemsDef ItemsDef => _itemsDef;
        
        private static DefsFacade _instance;
        public static DefsFacade I => _instance == null ? LoadDefs() : _instance;

        private static DefsFacade LoadDefs() => 
            _instance = Resources.Load<DefsFacade>("DefsFacade");
    }
}