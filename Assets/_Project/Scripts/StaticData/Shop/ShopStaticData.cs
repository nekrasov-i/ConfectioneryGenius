using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.StaticData.Shop
{
    [CreateAssetMenu(fileName = "ShopStaticData", menuName = "StaticData/ShopStaticData")]
    public class ShopStaticData : ScriptableObject
    {
        public List<ShopItem> ShopItems;
    }
}