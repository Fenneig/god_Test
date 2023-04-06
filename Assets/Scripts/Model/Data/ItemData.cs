using System;

namespace GoTTest.Model.Data
{
    [Serializable]
    public class ItemData
    {
        public string Id;
        public int Value;

        public ItemData(string id)
        {
            Id = id;
        }
    }
}