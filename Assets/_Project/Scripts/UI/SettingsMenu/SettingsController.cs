using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.SoundAndMusicService;
using _Project.Scripts.Services.WindowsService;
using GamePush;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.SettingsMenu
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private Image _settingsImage;
        [SerializeField] private Sprite _settingsRus;
        [SerializeField] private Sprite _settingsEng;
        [SerializeField] private Sprite _settingsTur;
        [SerializeField] private Button _exitButton;
        
        private IPlayerProgressService _playerProgressService;
        private IWindowsService _windowsService;
        private IGameSound _gameSound;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService, IWindowsService windowsService, IGameSound gameSound)
        {
            _gameSound = gameSound;
            _windowsService = windowsService;
            _playerProgressService = playerProgressService;
        }

        private void Awake()
        {
            _exitButton.onClick.AddListener(OnExitButtonClick);
            ChooseSettingsLanguage();
        }

        private void ChooseSettingsLanguage()
        {
            switch (_playerProgressService.Progress.Language)
            {
                case Language.Turkish:
                    _settingsImage.sprite = _settingsTur;
                    break;
                case Language.Russian:
                    _settingsImage.sprite = _settingsRus;
                    break;
                default:
                    _settingsImage.sprite = _settingsEng;
                    break;
            }
        }

        private void OnExitButtonClick()
        {
            _gameSound.PlaySound();
            Destroy(gameObject);
            _windowsService.OpenWindow(WindowID.GameMenu);
        }
    }
}