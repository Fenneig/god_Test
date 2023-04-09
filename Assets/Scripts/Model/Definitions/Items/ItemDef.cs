using GoTTest.Services;
using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    public abstract class ItemDef : ScriptableObject, IHaveId
    {
        [SerializeField] private string _id;
        
        public Sprite UIIcon;
        public float Weight;
        public int MaxStackSize;
        
        public ItemType ItemType { get; protected set; }
        public string Id => _id;
    }
}