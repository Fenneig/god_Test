using GoTTest.Model;
using GoTTest.Model.Definitions;
using GoTTest.Services;
using UnityEngine;

namespace GoTTest.Actions
{
    public class AddAmmoAction : MonoBehaviour
    {
        public void AddAmmo()
        {
            var maxPistolAmmoStackSize = DefsFacade.I.ItemsDef.Get(Idents.Items.PistolAmmo).MaxStackSize;
            var maxRifleAmmoStackSize = DefsFacade.I.ItemsDef.Get(Idents.Items.RifleAmmo).MaxStackSize;
            GameSession.Instance.Data.InventoryData.Add(Idents.Items.PistolAmmo, maxPistolAmmoStackSize);
            GameSession.Instance.Data.InventoryData.Add(Idents.Items.RifleAmmo, maxRifleAmmoStackSize);
        }
    }
}
