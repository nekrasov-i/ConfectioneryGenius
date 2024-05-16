using System;
using _Project.Scripts.Services.WindowsService;
using UnityEngine;

namespace _Project.Scripts.StaticData.Windows
{
    [Serializable]
    public class WindowsConfig
    {
        public WindowID WindowID; 
        public GameObject WindowPrefab;
    }
}