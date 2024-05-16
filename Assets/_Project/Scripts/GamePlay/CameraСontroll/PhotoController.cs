using _Project.Scripts.Services.InputService;
using _Project.Scripts.UI.JewelleryPanel;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.GamePlay.CameraСontroll
{
    public class PhotoController : MonoBehaviour
    {
        private IInputService _inputService;
        private CameraMovement _cameraMovement;

        private JewelleryPanelController _jewelleryPanelController;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Initialise(JewelleryPanelController jewelleryPanelController)
        {
            _jewelleryPanelController = jewelleryPanelController;
        }

        private void Awake()
        {
            _cameraMovement = new CameraMovement(Camera.main.transform);
        }

        private void Update()
        {
            if(_jewelleryPanelController == null) return;
            
            Vector2 rotationInput = _inputService.GetRotationInput();
            float zoomInput = _inputService.GetZoomInput();
            
            _cameraMovement.Move(rotationInput);
            _cameraMovement.Zoom(zoomInput);
        }
    }
}