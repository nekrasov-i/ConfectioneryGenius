using _Project.Scripts.Services.AdsService;
using _Project.Scripts.Services.ShopService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.Shop
{
    public class ShopItemButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private TMP_Text _priceText;

        private ShopController _shopController;
        private string _iD;
        private IShopService _shopService;

        [Inject]
        private void Construct(IShopService shopService)
        {
            _shopService = shopService;
        }

        public void Initialize(string iD, Sprite icon, string name, string description, int price)
        {
            _iD = iD;
            _icon.sprite = icon;
            _nameText.text = name;
            _descriptionText.text = description;
            _priceText.text = price.ToString();
        }

        private void Start()
        {
            _button.onClick.AddListener(Buy);
            _shopController = GetComponentInParent<ShopController>();
        }

        private void Buy()
        {
            _shopService.Buy(_iD);
            _shopController.CloseShop();
        }
    }
}