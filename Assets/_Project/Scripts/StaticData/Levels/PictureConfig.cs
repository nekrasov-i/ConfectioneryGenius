using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.StaticData.Levels
{
    [Serializable]
    public class PictureConfig
    {
        public int PictureID;
        public string RusName;
        public string EngName;
        public string TurName;
        public GameObject PicturePrefab;
        public Vector3 SpawnPosition; 
        public List<Material> PictureMaterials;
        public Sprite NonColorIcon;
        public Sprite ColorIcon;
        public int BrushBonus;
        public int FindNumberBonus;
    }
}