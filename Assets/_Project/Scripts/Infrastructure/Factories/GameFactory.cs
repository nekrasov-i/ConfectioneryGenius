using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.GamePlay.Voxel;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.StaticData.Jewellerys;
using _Project.Scripts.StaticData.Levels;
using _Project.Scripts.UI.HUD;
using _Project.Scripts.UI.JewelleryPanel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private GameObject _activePicture;

        private readonly DiContainer _diContainer;
        private readonly HUDRoot.Factory _hudFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly JewelleryPanelController.Factory _photoPanelFactory;
        private PictureConfig _activeConfig;
        private List<VoxelTrigger> _triggers = new List<VoxelTrigger>();
        private int _currentPictureID;
        
        public int CurrentPictureID => _currentPictureID;
        public List<VoxelTrigger> Triggers => _triggers;

        public GameFactory(DiContainer diContainer, HUDRoot.Factory hudFactory, IStaticDataService staticDataService, JewelleryPanelController.Factory photoPanelFactory)
        {
            _diContainer = diContainer;
            _hudFactory = hudFactory;
            _staticDataService = staticDataService;
            _photoPanelFactory = photoPanelFactory;
        }

        public HUDRoot CreateHUD()
        {
            HUDRoot hudRoot = _hudFactory.Create();
            hudRoot.GetComponent<PanelController>().Initialise(_activeConfig);
            return hudRoot;
        }

        public JewelleryPanelController CreatePhotoPanel()
        {
            JewelleryPanelController panelController = _photoPanelFactory.Create();
            panelController.Initialize();
            return panelController;
        }

        public void CreateJewelleryOnPanel(GameObject content, GameObject jewelleryTemplate)
        {
            foreach (KeyValuePair<JewelleryID,JewelleryStaticData> jewellery in _staticDataService.Jewellerys)
            {
                    var jewelleryIcon = _diContainer.InstantiatePrefab(jewelleryTemplate, content.transform);
                    Image image = jewelleryIcon.GetComponentInChildren<Image>();
                    image.sprite = jewellery.Value.Sprite;
                    image.SetNativeSize();
                    jewelleryIcon.GetComponent<JewelleryButton>().SetID(jewellery.Key);
            }
        }
        public void CreateJewellery(JewelleryID jewelleryID, Canvas parent, Image jewelleryTemplate)
        {
            var jewelleryIcon = _diContainer.InstantiatePrefab(jewelleryTemplate, parent.transform);
            Image image = jewelleryIcon.GetComponent<Image>();
            image.sprite = _staticDataService.ForJewellery(jewelleryID).Sprite;
            image.SetNativeSize();
        }

        public void CreatePicture(int pictureID)
        {
            _currentPictureID = pictureID;
            PictureConfig pictureConfig = _staticDataService.ForPicture(pictureID);

            Vector3 spawnPosition = pictureConfig.SpawnPosition;
            _activePicture = _diContainer.InstantiatePrefab(pictureConfig.PicturePrefab,spawnPosition, Quaternion.identity, null);
            _activeConfig = pictureConfig;
            _triggers = _activePicture.GetComponentsInChildren<VoxelTrigger>().ToList();
        }

        public void Cleanup()
        {
            
            if(_activePicture != null) GameObject.Destroy(_activePicture);
                
        }
    }
}