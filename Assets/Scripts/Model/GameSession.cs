using GoTTest.Model.Data;
using UnityEngine;

namespace GoTTest.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        public PlayerData Data => _data;
        public static ShopModel ShopModel { get; private set; }
        
        public static GameSession Instance;

        private void Awake()
        {
            ShopModel = new ShopModel(Data);
            
            Instance ??= this;
        }
    }
}