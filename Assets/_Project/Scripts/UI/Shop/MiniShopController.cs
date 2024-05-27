using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Infrastructure.FSM.State;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.ShopService;
using _Project.Scripts.Services.SoundAndMusicService;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.Services.WindowsService;
using _Project.Scripts.StaticData.UIText;
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

        [SerializeField] private Image _itemOneImage;
        [SerializeField] private TMP_Text _authorisation; 


        private IShopService _shopService;
        private IPlayerProgressService _playerProgressService;
        private IStaticDataService _staticDataService;
        private IGameStateMachine _gameStateMachine;
        private IWindowsService _windowsService;
        private IGameSound _gameSound;

        private string IdForFirstItem;

        [Inject]
        private void Construct(IShopService shopService, IPlayerProgressService playerProgressService,
            IStaticDataService staticDataService, IGameStateMachine gameStateMachine, IWindowsService windowsService,
            IGameSound gameSound)
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
            if (_playerProgressService.Progress.DisableAdverts)
            {
                IdForFirstItem = "4788";
                var shopItem = _staticDataService.ForShopItem(IdForFirstItem);
                _itemOneVolume.text = shopItem.Volume.ToString();
                _itemOnePrice.text = shopItem.Price.ToString();
                _itemOneImage.sprite = shopItem.Icon;
            }
            else
            {
                IdForFirstItem = "4054";
                var shopItem = _staticDataService.ForShopItem(IdForFirstItem);
                _itemOneVolume.text = GetShopItemName();
                _itemOnePrice.text = shopItem.Price.ToString();
                _itemOneImage.sprite = shopItem.Icon;
            }

            var shopItem2 = _staticDataService.ForShopItem("4789");
            _itemTwoVolume.text = shopItem2.Volume.ToString();
            _itemTwoPrice.text = shopItem2.Price.ToString();
            var shopItem3 = _staticDataService.ForShopItem("4790");
            _itemThreeVolume.text = shopItem3.Volume.ToString();
            _itemThreePrice.text = shopItem3.Price.ToString();
        }

        private string GetShopItemName()
        {
            var shopItem = _staticDataService.ForUIData(UIID.StopADS);
            string shopName;
            switch (_playerProgressService.Progress.Language)
            {
                case Language.Russian:
                    shopName = shopItem.RusText;
                    break;
                case Language.Turkish:
                    shopName = shopItem.TurText;
                    break;
                default:
                    shopName = shopItem.EngText;
                    break;
            }

            return shopName;
        }

        private void ChooseShopLanguage()
        {
            switch (_playerProgressService.Progress.Language)
            {
                case Language.Turkish:
                    _shopImage.sprite = _shopTur;
                    _authorisation.text = _staticDataService.ForUIData(UIID.MiniShop).TurText;
                    break;
                case Language.Russian:
                    _shopImage.sprite = _shopRus;
                    _authorisation.text = _staticDataService.ForUIData(UIID.MiniShop).RusText;
                    break;
                default:
                    _shopImage.sprite = _shopEng;
                    _authorisation.text = _staticDataService.ForUIData(UIID.MiniShop).EngText;
                    break;
            }

            _shopImage.SetNativeSize();
        }

        private void OnItemThreeButtonClick()
        {
            _gameSound.PlaySound();
            _shopService.Buy("4790");
            OnExitButtonClick();
        }

        private void OnItemTwoButtonClick()
        {
            _gameSound.PlaySound();
            _shopService.Buy("4789");
            OnExitButtonClick();
        }

        private void OnItemOneButtonClick()
        {
            _gameSound.PlaySound();
            _shopService.Buy(IdForFirstItem);
            OnExitButtonClick();
        }

        private void OnExitButtonClick()
        {
            _gameSound.PlaySound();
            Destroy(gameObject);
            if (_gameStateMachine.CurrentState is GameMenuState)
                _windowsService.OpenWindow(WindowID.GameMenu);
        }
    }
}