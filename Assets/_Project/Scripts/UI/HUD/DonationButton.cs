using _Project.Scripts.Services.WindowsService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.HUD
{
    public class DonationButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IWindowsService _windowsService;

        [Inject]
        private void Construct(IWindowsService windowsService)
        {
            _windowsService = windowsService;
        }
        
        private void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick() => 
            _windowsService.OpenWindow(WindowID.MiniShop);
    }
}