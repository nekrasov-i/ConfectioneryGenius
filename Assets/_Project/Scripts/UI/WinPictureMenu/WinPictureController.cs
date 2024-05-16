using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Infrastructure.FSM.State;
using _Project.Scripts.Services.AdsService;
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
        [SerializeField] private AudioSource _audioSource;
        
        private IGameStateMachine _gameStateMachine;
        private IAdsService _adsService;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine, IAdsService adsService)
        {
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
            _audioSource.Play();
            _gameStateMachine.Enter<PhotoState>();
            Destroy(gameObject);
        }

        private void OpenChoosePictureMenu()
        {
            _audioSource.Play();
            _adsService.ShowShowFullscreen(CloseWinMenu);
        }

        private void CloseWinMenu(bool b)
        {
            _audioSource.Play();
            _gameStateMachine.Enter<PictureChooseState>();
            Destroy(gameObject);
        }
    }
}