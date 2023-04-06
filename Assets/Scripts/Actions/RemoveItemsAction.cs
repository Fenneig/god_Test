using GoTTest.Model;
using UnityEngine;

namespace GoTTest.Actions
{
    public class RemoveItemsAction : MonoBehaviour
    {
        public void RemoveItems()
        {
            var invData = GameSession.Instance.Data.InventoryData.GetAll();
            if (invData.Length == 0)
            {
                Debug.LogError("There is nothing to remove");
                return;
            }
            
            var randomData = invData[Random.Range(0, invData.Length)];
            GameSession.Instance.Data.InventoryData.Remove(randomData.Id, randomData.Value);
        }
    }
}