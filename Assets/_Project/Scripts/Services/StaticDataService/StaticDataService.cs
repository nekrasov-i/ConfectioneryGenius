using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Services.WindowsService;
using _Project.Scripts.StaticData.Jewellerys;
using _Project.Scripts.StaticData.Levels;
using _Project.Scripts.StaticData.Shop;
using _Project.Scripts.StaticData.UIText;
using _Project.Scripts.StaticData.Windows;
using UnityEngine;

namespace _Project.Scripts.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataWindows = "StaticData/Windows/WindowsStaticData";

        private Dictionary<WindowID, WindowsConfig> _windowsConfig;
        private Dictionary<int, PictureConfig> _pictureConfigs;
        private Dictionary<JewelleryID, JewelleryStaticData> _jewellerys;
        private Dictionary<string,ShopItem> _shopConfigs;
        private Dictionary<UIID, UIData> _uiData;

        public Dictionary<int, PictureConfig> PictureConfigs => _pictureConfigs;

        public Dictionary<JewelleryID, JewelleryStaticData> Jewellerys => _jewellerys;

        public Dictionary<string, ShopItem> ShopConfigs => _shopConfigs;

        public void Initialize()
        {
            _windowsConfig = Resources
                .Load<WindowsStaticData>(StaticDataWindows)
                .WindowsConfig.ToDictionary(x => x.WindowID, x => x);
            _pictureConfigs = Resources
                .Load<LevelStaticData>("StaticData/Levels/LevelData")
                .PictureConfig.ToDictionary(x => x.PictureID, x => x);
            _jewellerys = Resources.LoadAll<JewelleryStaticData>("StaticData/Jewellerys")
                .ToDictionary(x => x.JewelleryID, x => x);
            _shopConfigs = Resources.Load<ShopStaticData>("StaticData/Shop/ShopStaticData")
                .ShopItems.ToDictionary(x => x.Id, x => x);
            _uiData = Resources.Load<UIStaticData>("StaticData/UI/UIStaticData")
                .UIDataList.ToDictionary(x => x.ID, x => x);
        }

        public WindowsConfig ForWindow(WindowID windowId) =>
            _windowsConfig.TryGetValue(windowId, out WindowsConfig windowsConfig)
                ? windowsConfig
                : null;
        public PictureConfig ForPicture(int pictureID) =>
            _pictureConfigs.TryGetValue(pictureID, out PictureConfig pictureConfig)
                ? pictureConfig
                : null;
        public JewelleryStaticData ForJewellery(JewelleryID jewelleryID) =>
            Jewellerys.TryGetValue(jewelleryID, out JewelleryStaticData jewellery)
                ? jewellery
                : null;

        public ShopItem ForShopItem(string id) =>
            ShopConfigs.TryGetValue(id, out ShopItem shopItem)
                ? shopItem
                : null;
        public UIData ForUIData(UIID iUId) =>
            _uiData.TryGetValue(iUId, out UIData uiData)
                ? uiData
                : null;
    }
}