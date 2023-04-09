using GoTTest.Services;
using UnityEngine;

namespace GoTTest.Model.Definitions.Items
{
    public abstract class ItemDef : ScriptableObject, IHaveId
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _uiIcon;
        [SerializeField] private float _weight;
        [SerializeField] private int _maxStackSize;

        public string Id => _id;
        public Sprite UIIcon => _uiIcon;
        public float Weight => _weight;
        public int MaxStackSize => _maxStackSize;
        public ItemType ItemType { get; protected set; }
    }
}