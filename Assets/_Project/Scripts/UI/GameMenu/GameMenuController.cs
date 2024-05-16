using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Infrastructure.FSM.State;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.SoundAndMusicService;
using _Project.Scripts.Services.WindowsService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.GameMenu
{
    public class GameMenuController : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _settingsButton;

        private IGameStateMachine _gameStateMachine;
        private IWindowsService _windowsService;
        private IPlayerProgressService _playerProgressService;
        private IGameFactory _gameFactory;
        private IGameSound _gameSound;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IWindowsService windowsService,
            IPlayerProgressService playerProgressService, IGameFactory gameFactory, IGameSound gameSound)
        {
            _gameSound = gameSound;
            _gameFactory = gameFactory;
            _playerProgressService = playerProgressService;
            _windowsService = windowsService;
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _startButton.onClick.AddListener(StartGame);
            _shopButton.onClick.AddListener(StartShop);
            _settingsButton.onClick.AddListener(StartSettings);
        }

        private void StartSettings()
        {
            _windowsService.OpenWindow(WindowID.Settings);
            PlayAndDestroy();
        }

        private void StartShop()
        {
            _windowsService.OpenWindow(WindowID.Shop);
            PlayAndDestroy();
        }

        private void StartGame()
        {
            if (!_playerProgressService.Progress.PictureIds.Contains(0))
            {
                _gameFactory.CreatePicture(0);
                _gameStateMachine.Enter<GameLoopState>();
            }
            else
                _gameStateMachine.Enter<PictureChooseState>();

            PlayAndDestroy();
        }

        private void PlayAndDestroy()
        {
            _gameSound.PlaySound();
            Destroy(gameObject);
        }
    }
}