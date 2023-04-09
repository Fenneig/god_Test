using System;

namespace GoTTest.Model.Data.Purchases
{
    [Serializable]
    public class PurchaseProgress
    {
        public string Id;
        public int Level;

        public PurchaseProgress(string id, int level)
        {
            Id = id;
            Level = level;
        }
    }
}