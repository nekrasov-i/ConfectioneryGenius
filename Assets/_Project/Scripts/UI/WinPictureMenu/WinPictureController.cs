using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Infrastructure.FSM.State;
using _Project.Scripts.Services.AdsService;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.SoundAndMusicService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.WinPictureMenu
{
    public class WinPictureController : MonoBehaviour
    {
        [SerializeField] private Button _winButton;
        [SerializeField] private Button _photoButton;
        [SerializeField] private TMP_Text _brushBonusText;
        [SerializeField] private TMP_Text _findNumberText;
        
        private IGameStateMachine _gameStateMachine;
        private IAdsService _adsService;
        private IGameSound _gameSound;
        private IPlayerProgressService _playerProgressService;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine, IAdsService adsService, IGameSound gameSound, IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
            _gameSound = gameSound;
            _adsService = adsService;
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize(int brushBonus, int findNumber)
        {
            _brushBonusText.text = brushBonus.ToString();
            _findNumberText.text = findNumber.ToString();
        }
        private void Awake()
        {
            _winButton.onClick.AddListener(OpenChoosePictureMenu);
            _photoButton.onClick.AddListener(OpenPhotoState);
        }

        private void OpenPhotoState()
        {
            _gameSound.PlaySound();
            _gameStateMachine.Enter<PhotoState>();
            Destroy(gameObject);
        }

        private void OpenChoosePictureMenu()
        {
            _gameSound.PlaySound();
            if (_playerProgressService.Progress.DisableAdverts)
            {
                CloseWinMenu(true);
            }
            else
            {
                _adsService.ShowShowFullscreen(CloseWinMenu);
            }
        }

        private void CloseWinMenu(bool b)
        {
            _gameSound.PlayMusic();
            _gameStateMachine.Enter<PictureChooseState>();
            Destroy(gameObject);
        }
    }
}