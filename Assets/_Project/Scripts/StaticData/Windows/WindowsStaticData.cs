using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.StaticData.Windows
{
    [CreateAssetMenu(fileName = "WindowsStaticData", menuName = "StaticData/WindowsStaticData")]
    public class WindowsStaticData: ScriptableObject
    {
        public List<WindowsConfig> WindowsConfig;
    }
}