using GoTTest.Model;
using GoTTest.Services;
using UnityEngine;

namespace GoTTest
{
    public class AddInventoryItem : MonoBehaviour
    {
        public void AddAmmo()
        {
            Debug.Log("added ammo");
            GameSession.Instance.Data.InventoryData.Add(Idents.Items.PistolAmmo, 50);
            GameSession.Instance.Data.InventoryData.Add(Idents.Items.RifleAmmo, 10);
        }
    }
}
