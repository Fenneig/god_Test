using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    public class ItemDef : ScriptableObject
    {
        public string Id;
        public Sprite UIIcon;
        public float Weight;
        public int MaxStackSize;
        public ItemType ItemType { get; protected set; }
    }
}