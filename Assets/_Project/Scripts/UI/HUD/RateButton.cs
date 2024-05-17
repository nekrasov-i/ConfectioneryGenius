using GamePush;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.HUD
{
    public class RateButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Start() => 
            _button.onClick.AddListener(OnClick);

        private void OnClick() => 
            GP_App.ReviewRequest();
        
    }
}