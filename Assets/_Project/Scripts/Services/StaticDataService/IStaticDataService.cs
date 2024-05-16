using System.Collections.Generic;
using _Project.Scripts.Services.WindowsService;
using _Project.Scripts.StaticData.Jewellerys;
using _Project.Scripts.StaticData.Levels;
using _Project.Scripts.StaticData.Shop;
using _Project.Scripts.StaticData.UIText;
using _Project.Scripts.StaticData.Windows;

namespace _Project.Scripts.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        WindowsConfig ForWindow(WindowID windowId);
        PictureConfig ForPicture(int pictureID);
        Dictionary<int, PictureConfig> PictureConfigs { get; }
        Dictionary<JewelleryID, JewelleryStaticData> Jewellerys { get; }
        Dictionary<string, ShopItem> ShopConfigs { get; }
        JewelleryStaticData ForJewellery(JewelleryID jewelleryID);
        ShopItem ForShopItem(string id);
        UIData ForUIData(UIID iUId);
    }
}