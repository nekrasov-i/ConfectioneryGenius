using System.Collections.Generic;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.Services.WindowsService;
using _Project.Scripts.StaticData.Levels;
using _Project.Scripts.StaticData.Shop;
using _Project.Scripts.StaticData.Windows;
using _Project.Scripts.UI.ChoosePicture;
using _Project.Scripts.UI.Interface;
using _Project.Scripts.UI.Shop;
using _Project.Scripts.UI.WinPictureMenu;
using GamePush;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly DiContainer _diContainer;
        private readonly InterfaceController.Factory _interfaceFactory;
        private readonly IGameFactory _gameFactory;
        private readonly IPlayerProgressService _playerProgressService;

        private List<GameObject> _buttons;
        private InterfaceController _interface;
        public List<GameObject> Buttons => _buttons;

        public UIFactory(IStaticDataService staticDataService, DiContainer diContainer,
            InterfaceController.Factory interfaceFactory, IGameFactory gameFactory,
            IPlayerProgressService playerProgressService)
        {
            _staticDataService = staticDataService;
            _diContainer = diContainer;
            _interfaceFactory = interfaceFactory;
            _gameFactory = gameFactory;
            _playerProgressService = playerProgressService;
        }


        public void CreateGameMenu() =>
            CreateWindow(WindowID.GameMenu);

        public void CreateWinMenu()
        {
            GameObject menu = CreateWindow(WindowID.WinMenu);
            UIParticleSystem[] particleSystems = menu.GetComponentsInChildren<UIParticleSystem>();
            foreach (UIParticleSystem particleSystem in particleSystems)
            {
                particleSystem.SetBakeCamera(_interface.Camera);
            }

            PictureConfig data = _staticDataService.PictureConfigs[_gameFactory.CurrentPictureID];
            menu.GetComponent<WinPictureController>().Initialize(data.BrushBonus, data.FindNumberBonus);
        }

        public void CreateChooseLevel() =>
            CreateWindow(WindowID.ChooseLevel);

        public void CreateChoosePicture() =>
            CreateWindow(WindowID.ChoosePicture);

        public void CreateShopWindow() =>
            CreateWindow(WindowID.Shop);

        public void CreateSettingsWindow() =>
            CreateWindow(WindowID.Settings);

        public void CreateMiniShop() =>
            CreateWindow(WindowID.MiniShop);

        public void CreateInterface() =>
            _interface = _interfaceFactory.Create();

        public void CreatePictureButton(GameObject buttonTemplate, GameObject content)
        {
            foreach (KeyValuePair<int, PictureConfig> pictureConfig in _staticDataService.PictureConfigs)
            {
                var button = Object.Instantiate(buttonTemplate, content.transform);
                var icon = _playerProgressService.Progress.PictureIds.Contains(pictureConfig.Value.PictureID) ? pictureConfig.Value.ColorIcon : pictureConfig.Value.NonColorIcon;
                var pictureName = GetPictureNameLanguage(pictureConfig);
                button.GetComponent<PictureInfo>().Initialize(pictureConfig.Value.PictureID, icon, pictureName);
                Buttons.Add(button);
            }
        }

        private string GetPictureNameLanguage(KeyValuePair<int, PictureConfig> pictureConfig)
        {
            string pictureName;
            switch (_playerProgressService.Progress.Language)
            {
                case Language.Turkish:
                    pictureName = pictureConfig.Value.TurName;
                    break;
                case Language.Russian:
                    pictureName = pictureConfig.Value.RusName;
                    break;
                default:
                    pictureName = pictureConfig.Value.EngName;
                    break;
            }

            return pictureName;
        }

        public void CreateShopButton(GameObject buttonTemplate, Transform content)
        {
            foreach (KeyValuePair<string, ShopItem> shopConfig in _staticDataService.ShopConfigs)
            {
                var button = _diContainer.InstantiatePrefab(buttonTemplate, content);
                button.GetComponent<ShopItemButton>().Initialize(shopConfig.Value.Id, shopConfig.Value.Icon,
                    shopConfig.Value.Name, shopConfig.Value.Description, shopConfig.Value.Price);
            }
        }

        public void Cleanup()
        {
            _buttons = new List<GameObject>();
        }

        private GameObject CreateWindow(WindowID windowID)
        {
            WindowsConfig config = _staticDataService.ForWindow(windowID);
            return _diContainer.InstantiatePrefab(config.WindowPrefab, _interface.Canvas.transform);
        }
    }
}