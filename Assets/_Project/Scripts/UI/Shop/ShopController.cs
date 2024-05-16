using _Project.Scripts.Services.WindowsService;
using _Project.Scripts.UI.Factories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonTemplate;
        [SerializeField] private Transform _content;
        [SerializeField] private Button _exitButton;

        private IUIFactory _uiFactory;
        private IWindowsService _windowsService;

        [Inject]
        private void Construct(IUIFactory uiFactory, IWindowsService windowsService)
        {
            _windowsService = windowsService;
            _uiFactory = uiFactory;
        }

        private void Start()
        {
            _uiFactory.CreateShopButton(_buttonTemplate, _content);
            _exitButton.onClick.AddListener(CloseShop);
            //foreach (GameObject button in _uiFactory.Buttons)
            // button.GetComponent<Button>().onClick
            //     .AddListener(() => ChooseShopItem(button.GetComponent<ShopItemInfo>()));
        }

        public void CloseShop()
        {
            Destroy(gameObject);
            _windowsService.OpenWindow(WindowID.GameMenu);
        }
    }
}