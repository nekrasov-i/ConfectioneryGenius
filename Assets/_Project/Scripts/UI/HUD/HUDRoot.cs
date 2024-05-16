using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.HUD
{
    public class HUDRoot : MonoBehaviour, IHUDRoot
    {



        public class Factory : PlaceholderFactory<HUDRoot>
        {
            
        }
    }
}