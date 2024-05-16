using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Infrastructure.FSM.State;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.ShopService;
using _Project.Scripts.Services.SoundAndMusicService;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.Services.WindowsService;
using GamePush;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.Shop
{
    public class MiniShopController : MonoBehaviour
    {
        [SerializeField] private Image _shopImage;
        [SerializeField] private Sprite _shopRus;
        [SerializeField] private Sprite _shopEng;
        [SerializeField] private Sprite _shopTur;

        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _itemOneButton;
        [SerializeField] private Button _itemTwoButton;
        [SerializeField] private Button _itemThreeButton;

        [SerializeField] private TMP_Text _itemOneVolume;
        [SerializeField] private TMP_Text _itemTwoVolume;
        [SerializeField] private TMP_Text _itemThreeVolume;
        [SerializeField] private TMP_Text _itemOnePrice;
        [SerializeField] private TMP_Text _itemTwoPrice;
        [SerializeField] private TMP_Text _itemThreePrice;

        private IShopService _shopService;
        private IPlayerProgressService _playerProgressService;
        private IStaticDataService _staticDataService;
        private IGameStateMachine _gameStateMachine;
        private IWindowsService _windowsService;
        private IGameSound _gameSound;

        [Inject]
        private void Construct(IShopService shopService, IPlayerProgressService playerProgressService,
            IStaticDataService staticDataService, IGameStateMachine gameStateMachine, IWindowsService windowsService, IGameSound gameSound)
        {
            _gameSound = gameSound;
            _windowsService = windowsService;
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
            _playerProgressService = playerProgressService;
            _shopService = shopService;
        }

        private void Awake()
        {
            _exitButton.onClick.AddListener(OnExitButtonClick);
            _itemOneButton.onClick.AddListener(OnItemOneButtonClick);
            _itemTwoButton.onClick.AddListener(OnItemTwoButtonClick);
            _itemThreeButton.onClick.AddListener(OnItemThreeButtonClick);
            ChooseShopLanguage();
            InitializeShopItem();
        }

        private void InitializeShopItem()
        {
            var shopItem = _staticDataService.ForShopItem("2");
            _itemOneVolume.text = shopItem.Volume.ToString();
            _itemOnePrice.text = shopItem.Price.ToString();
            var shopItem2 = _staticDataService.ForShopItem("3");
            _itemTwoVolume.text = shopItem2.Volume.ToString();
            _itemTwoPrice.text = shopItem2.Price.ToString();
            var shopItem3 = _staticDataService.ForShopItem("4");
            _itemThreeVolume.text = shopItem3.Volume.ToString();
            _itemThreePrice.text = shopItem3.Price.ToString();
        }

        private void ChooseShopLanguage()
        {
            switch (_playerProgressService.Progress.Language)
            {
                case Language.Turkish:
                    _shopImage.sprite = _shopTur;
                    break;
                case Language.Russian:
                    _shopImage.sprite = _shopRus;
                    break;
                default:
                    _shopImage.sprite = _shopEng;
                    break;
            }

            _shopImage.SetNativeSize();
        }

        private void OnItemThreeButtonClick()
        {
            _gameSound.PlaySound();
            _shopService.Buy("4");
            OnExitButtonClick();
        }

        private void OnItemTwoButtonClick()
        {
            _gameSound.PlaySound();
            _shopService.Buy("3");
            OnExitButtonClick();
        }

        private void OnItemOneButtonClick()
        {
            _gameSound.PlaySound();
            _shopService.Buy("2");
            OnExitButtonClick();
        }

        private void OnExitButtonClick()
        {
            _gameSound.PlaySound();
                Destroy(gameObject);
            if(_gameStateMachine.CurrentState is GameMenuState) 
                _windowsService.OpenWindow(WindowID.GameMenu);
        }
    }
}