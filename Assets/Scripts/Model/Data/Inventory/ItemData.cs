using System;

namespace GoTTest.Model.Data.Inventory
{
    [Serializable]
    public class ItemData
    {
        public string Id;
        public int Amount;
        public int InventoryIndex;

        public ItemData(string id)
        {
            Id = id;
            InventoryIndex = -1;
        }
    }
}