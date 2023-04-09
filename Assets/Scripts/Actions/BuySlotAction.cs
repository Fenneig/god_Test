using GoTTest.Model;
using GoTTest.Services;
using UnityEngine;

namespace GoTTest.Actions
{
    public class BuySlotAction : MonoBehaviour
    {
        public void Buy()
        {
            GameSession.ShopModel.BuyLot(Idents.ShopDefs.InventorySlots);
        }
    }
}