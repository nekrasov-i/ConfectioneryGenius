using _Project.Scripts.GamePlay.Voxel;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Infrastructure.FSM.State;
using _Project.Scripts.Services.PlayerProgressService;
using UnityEngine;

namespace _Project.Scripts.GamePlay.CameraСontroll
{
    public class ObjectInteraction
    {
        private const float _2XBrushConst = 0.7f;
        private const float _simpleBrushConst = 0.1f;
        private Material _material;
        private int _index;
        private readonly IGameFactory _gameFactory;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IPlayerProgressService _playerProgressService;
        private int _size;
        private float _interactRadius = _simpleBrushConst;

        public ObjectInteraction(IGameFactory gameFactory, IGameStateMachine gameStateMachine,
            IPlayerProgressService playerProgressService)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
            _playerProgressService = playerProgressService;
        }

        public void Cleanup() => _material = null;

        public void SetMaterialAndColorIndex(Material material, int index)
        {
            _index = index;
            _material = material;
        }

        public void Interact(Vector3 interactInput)
        {
            Ray ray = Camera.main.ScreenPointToRay(interactInput);
            RaycastHit hit;
            Vector3 worldPosition;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                worldPosition = hit.point;

                Collider[] colliders = Physics.OverlapSphere(worldPosition, _interactRadius);
                foreach (var collider in colliders)
                {
                    if (!collider.TryGetComponent<VoxelTrigger>(out var trigger)) continue;
                    if (_material == null) return;
                    if (trigger.IsVoxelPainted(_index, _material))
                    {
                        _gameFactory.Triggers.Remove(trigger);
                        if (_size == 1) _playerProgressService.Progress.SpendPaintBrushQuantity(1);
                    }
                }
            }

            if (_gameFactory.Triggers.Count == 0) Win();
        }

        private void Win() =>
            _gameStateMachine.Enter<PictureDoneState>();

        public void SetBrushSize(int size)
        {
            if (_size == size || (_playerProgressService.Progress.CurrentPaintBrush == 0 && size == 1)) return;
            _interactRadius = _size < size ? _2XBrushConst : _simpleBrushConst;
            _size = size;
        }
    }
}