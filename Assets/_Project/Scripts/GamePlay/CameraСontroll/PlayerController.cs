using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Services.InputService;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.UI.HUD;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.GamePlay.CameraСontroll
{
    public class PlayerController : MonoBehaviour
    {
        private IInputService _inputService;

        private CameraMovement _cameraMovement;
        private ObjectInteraction _objectInteraction;
        private PanelController _panelController;
        private IGameFactory _gameFactory;
        private IGameStateMachine _gameStateMachine;
        private IPlayerProgressService _playerProgressService;

        [Inject]
        public void Construct(IInputService inputService, IGameFactory gameFactory, IGameStateMachine gameStateMachine,
            IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _inputService = inputService;
        }

        public void Initialise(PanelController panelController)
        {
            if (panelController != null)
            {
                _panelController = panelController;
                _panelController.BrushSizeChanged += OnBrushSizeChanged;
                _panelController.BrushChanged += OnBrushChanged;
                _panelController.FindNumberPressed += OnFindNumberPressed;
                _playerProgressService.Progress.BrushBonusOver += OnBrushBonusOver;
            }
            else
            {
                _panelController.BrushSizeChanged -= OnBrushSizeChanged;
                _panelController.FindNumberPressed -= OnFindNumberPressed;
                _panelController.BrushChanged -= OnBrushChanged;
                _panelController = null;
                _playerProgressService.Progress.BrushBonusOver -= OnBrushBonusOver;
            }
            _objectInteraction.Cleanup();
        }

        private void OnBrushBonusOver() =>
            _objectInteraction.SetBrushSize(0);

        private void OnBrushSizeChanged(int size) =>
            _objectInteraction.SetBrushSize(size);

        private void OnFindNumberPressed() =>
            _cameraMovement.FindNumber(_gameFactory.Triggers[0]);

        private void OnBrushChanged(int index, Material material) =>
            _objectInteraction.SetMaterialAndColorIndex(material, index);

        private void Awake()
        {
            _cameraMovement = new CameraMovement(Camera.main.transform, _playerProgressService);
            _objectInteraction = new ObjectInteraction(_gameFactory, _gameStateMachine, _playerProgressService);
        }

        private void Update()
        {
            if (_panelController == null) return;

            Vector2 rotationInput = _inputService.GetRotationInput();
            float zoomInput = _inputService.GetZoomInput();
            if (_inputService.GetInteractInput(out Vector3 interactInput))
            {
                _objectInteraction.Interact(interactInput);
            }

            _cameraMovement.Move(rotationInput);
            _cameraMovement.Zoom(zoomInput);
        }
    }
}