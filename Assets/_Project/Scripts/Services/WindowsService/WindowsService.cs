using System;
using _Project.Scripts.UI.Factories;

namespace _Project.Scripts.Services.WindowsService
{
    public class WindowsService: IWindowsService
    {
        private readonly IUIFactory _uiFactory;
        
        public WindowsService(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void OpenWindow(WindowID windowID)
        {
            switch (windowID)
            {
                case WindowID.GameMenu:
                    _uiFactory.CreateGameMenu();
                    break;
                case WindowID.ChooseLevel:
                    _uiFactory.CreateChooseLevel();
                    break;
                case WindowID.ChoosePicture:
                    _uiFactory.CreateChoosePicture();
                    break;
                case WindowID.WinMenu:
                    _uiFactory.CreateWinMenu();
                    break;
                case WindowID.Shop:
                    _uiFactory.CreateShopWindow();
                    break;
                case WindowID.Settings:
                    _uiFactory.CreateSettingsWindow();
                    break;
                case WindowID.MiniShop:
                    _uiFactory.CreateMiniShop();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(windowID), windowID, null);
            }
        }
    }
}