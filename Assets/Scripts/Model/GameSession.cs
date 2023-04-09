using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GoTTest.Model.Data;
using GoTTest.Services;
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
            Load();
            
            ShopModel = new ShopModel(Data);
            
            Instance ??= this;
        }

        private void Save()
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat"); 
            SaveData data = new SaveData
            {
                InventoryData = _data.InventoryData.GetAll(),
                PurchasesData = _data.PurchasesData.GetAll()
            };
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Game data saved!");
        }

        private void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
                SaveData data = (SaveData)bf.Deserialize(file);
                file.Close();
                var inventoryData = data.InventoryData;
                var purchaseData = data.PurchasesData;

                foreach (var itemData in inventoryData)
                {
                    _data.InventoryData.AddItem(itemData);
                }

                foreach (var purchaseProgress in purchaseData)
                {
                    _data.PurchasesData.AddExistPurchase(purchaseProgress);
                }
                
                Debug.Log("Game data loaded!");
            }
            else
            {
                Debug.LogError("There is no save data!");
            }
        }

        [ContextMenu("Reset save")]
        public void ResetSave()
        {
            if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
            {
                File.Delete(Application.persistentDataPath + "/SaveData.dat");
                Debug.Log("Data reset complete!");
            }
            else
            {
                Debug.LogError("No save data to delete.");
            }
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}