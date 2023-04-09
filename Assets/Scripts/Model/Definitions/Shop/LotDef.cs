using System;
using UnityEngine;

namespace GoTTest.Model.Definitions.Shop
{
    [Serializable]
    public struct LotDef
    {
        [SerializeField] private float _value; 
        [SerializeField] private int _price;

        public float Value => _value;
        public int Price => _price;
    }
}