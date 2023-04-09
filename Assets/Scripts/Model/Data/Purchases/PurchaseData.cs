using System;
using System.Collections.Generic;
using System.Linq;
using GoTTest.Model.Definitions;
using GoTTest.Model.Definitions.Shop;
using UnityEngine;

namespace GoTTest.Model.Data.Purchases
{
    [Serializable]
    public class PurchaseData
    {
        [SerializeField] private List<PurchaseProgress> _purchases;

        public int GetPurchaseState(string id) =>
            (from purchase in _purchases where purchase.Id == id select purchase.Level).FirstOrDefault();

        public float GetTotalPurchasedAmount(string id)
        {
            var level = GetPurchaseState(id);

            var lot = DefsFacade.I.ShopRepository.Get(id);

            var amount = 0f;

            if (lot is MultiplyLot)
            {
                var item = lot as MultiplyLot;
                for (int i = 0; i <= level; i++)
                {
                    amount += item.Levels[i].Value;
                }
            }
            else
            {
                var item = lot as SingleLot;
                amount = item.Lot.Value;
            }

            return amount;
        }

        public void MakePurchase(string id)
        {
            var progress = _purchases.FirstOrDefault(x => x.Id == id);
            if (progress == null)
            {
                _purchases.Add(new PurchaseProgress(id, 0));
            }
            else
            {
                progress.Level++;
            }
        }

        public PurchaseProgress[] GetAll() =>
            _purchases.ToArray();

        public void AddExistPurchase(PurchaseProgress purchaseData)
        {
            _purchases.Add(purchaseData);
        }

        public bool HasPurchase(string id) =>
            _purchases.Any(purchase => purchase.Id == id);
    }
}