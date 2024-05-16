using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.StaticData.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/LevelData")]
    public class LevelStaticData : ScriptableObject
    {
        public List<PictureConfig> PictureConfig;
        public GameObject ChoosePicturePanel;
    }
}