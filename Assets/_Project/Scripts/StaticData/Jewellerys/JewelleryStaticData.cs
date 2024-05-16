using UnityEngine;

namespace _Project.Scripts.StaticData.Jewellerys
{
    [CreateAssetMenu(fileName = "JewelleryStaticData", menuName = "StaticData/JewelleryStaticData")]
    public class JewelleryStaticData: ScriptableObject
    {
        public JewelleryID JewelleryID;
        public Sprite Sprite;
    }
}