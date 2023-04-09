using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GoTTest.Model.Data.Purchases
{
    [Serializable]
    public class PurchaseData
    {
        [SerializeField] private List<PurchaseProgress> _purchases;

        public int GetPurchaseState(string id) =>
            (from purchase in _purchases where purchase.Id == id select purchase.Level).FirstOrDefault();

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
    }
}