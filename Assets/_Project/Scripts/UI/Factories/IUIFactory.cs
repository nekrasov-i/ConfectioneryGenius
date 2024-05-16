using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.UI.Factories
{
    public interface IUIFactory
    {
        void Cleanup();
        void CreateGameMenu();
        void CreateChooseLevel();
        void CreateChoosePicture();
        void CreatePictureButton(GameObject buttonTemplate, GameObject content);
        List<GameObject> Buttons { get; }
        void CreateWinMenu();
        void CreateShopButton(GameObject buttonTemplate, Transform content);
        void CreateShopWindow();
        void CreateSettingsWindow();
        void CreateMiniShop();
        void CreateInterface();
    }
}