using GoTTest.Model;
using GoTTest.Services;
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
                Debug.LogError(Idents.Errors.NothingToRemove);
                return;
            }
            
            var randomData = invData[Random.Range(0, invData.Length)];
            GameSession.Instance.Data.InventoryData.RemoveAtIndex(randomData.InventoryIndex);
        }
    }
}