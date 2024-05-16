using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.WindowsService;
using GamePush;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.SettingsMenu
{
    public class LanguageSettingsControl : MonoBehaviour
    {
        [SerializeField] private Button _buttonRUS;
        [SerializeField] private Button _buttonENG;
        [SerializeField] private Button _buttonTUR;

        private IPlayerProgressService _playerProgressService;
        private IWindowsService _windowsService;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService, IWindowsService windowsService)
        {
            _windowsService = windowsService;
            _playerProgressService = playerProgressService;
        }

        private void Awake()
        {
            _buttonRUS.onClick.AddListener((() => ChangeLanguage(Language.Russian)));
            _buttonENG.onClick.AddListener((() => ChangeLanguage(Language.English)));
            _buttonTUR.onClick.AddListener((() => ChangeLanguage(Language.Turkish)));
        }

        private void ChangeLanguage(Language language)
        {
            _playerProgressService.Progress.SetLanguage(language);
            Destroy(gameObject);
            _windowsService.OpenWindow(WindowID.GameMenu);
        }
    }
}