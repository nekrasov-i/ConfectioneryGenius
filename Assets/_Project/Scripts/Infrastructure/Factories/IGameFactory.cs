using System.Collections.Generic;
using _Project.Scripts.GamePlay.Voxel;
using _Project.Scripts.StaticData.Jewellerys;
using _Project.Scripts.UI.HUD;
using _Project.Scripts.UI.JewelleryPanel;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Infrastructure.Factories
{
    public interface IGameFactory
    {
        HUDRoot CreateHUD();
        void Cleanup();
        List<VoxelTrigger> Triggers { get; }
        int CurrentPictureID { get; }
        void CreatePicture(int pictureID);
        JewelleryPanelController CreatePhotoPanel();
        void CreateJewelleryOnPanel(GameObject content, GameObject jewelleryTemplate);
        void CreateJewellery(JewelleryID jewelleryID, Canvas getComponentInParent, Image jewelleryTemplate);
    }
}