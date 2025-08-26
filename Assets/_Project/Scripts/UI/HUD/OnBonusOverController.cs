using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.WindowsService;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.HUD
{
    public class OnBonusOverController : MonoBehaviour
    {
        private IWindowsService _windowsService;
        private IPlayerProgressService _playerProgressService;

        [Inject]
        private void Construct(IWindowsService windowsService, IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
            _windowsService = windowsService;
        }

        private void OnEnable()
        {
            // _playerProgressService.Progress.BrushBonusOver += OnBrushBonusOver;
            // _playerProgressService.Progress.FindNumberBonusOver += OnFindNumberBonusOver;
        }

        private void OnDisable()
        {
            // _playerProgressService.Progress.BrushBonusOver -= OnBrushBonusOver;
            // _playerProgressService.Progress.FindNumberBonusOver -= OnFindNumberBonusOver;
        }

        private void OnFindNumberBonusOver()
        {
            Debug.Log("Open MiniShop");
            _windowsService.OpenWindow(WindowID.MiniShop);
        }

        private void OnBrushBonusOver()
        {
            Debug.Log("Open MiniShop");
            _windowsService.OpenWindow(WindowID.MiniShop);
        }
    }
}