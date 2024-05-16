using System;
using UnityEngine;

namespace _Project.Scripts.StaticData.Shop
{
    [Serializable]
    public class ShopItem
    {
        public string Id;
        public string Name;
        public string Description;
        public int Volume;
        public int Price;
        public Sprite Icon;
    }
}

