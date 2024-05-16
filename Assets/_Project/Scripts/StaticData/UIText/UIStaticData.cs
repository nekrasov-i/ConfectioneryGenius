using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.StaticData.UIText
{
    [CreateAssetMenu(fileName = "UIStaticData", menuName = "StaticData/UIStaticData")]
    public class UIStaticData: ScriptableObject
    {
        public List<UIData> UIDataList;
    }
}