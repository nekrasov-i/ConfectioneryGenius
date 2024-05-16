using _Project.Scripts.GamePlay.Voxel;
using _Project.Scripts.Services.PlayerProgressService;
using UnityEngine;

namespace _Project.Scripts.GamePlay.CameraСontroll
{
    public class CameraMovement
    {
        private readonly Transform _cameraTransform;
        private readonly IPlayerProgressService _playerProgressService;

        private Vector3 _targetPosition;
        private float _rotationSpeed = 80f;
        private float _zoomSpeed = 20f;


        public CameraMovement(Transform cameraTransform, IPlayerProgressService playerProgressService)
        {
            _cameraTransform = cameraTransform;
            _playerProgressService = playerProgressService;
            _targetPosition = Vector3.zero;
        }

        public CameraMovement(Transform cameraTransform)
        {
            _cameraTransform = cameraTransform;
            _targetPosition = Vector3.zero;
        }
        public void Move(Vector2 rotationInput)
        {
            _cameraTransform.RotateAround(_targetPosition, Vector3.up, rotationInput.x * _rotationSpeed * Time.deltaTime);
            _cameraTransform.RotateAround(_targetPosition, _cameraTransform.right, rotationInput.y * _rotationSpeed * Time.deltaTime);
        }

        public void Zoom(float zoomInput)
        {
            Vector3 zoomDirection = (_targetPosition - _cameraTransform.position).normalized;
            _cameraTransform.Translate(zoomDirection * zoomInput * _zoomSpeed, Space.World);
        }


        public void FindNumber(VoxelTrigger gameFactoryTrigger)
        {
            if(_playerProgressService == null) return;
            if(_playerProgressService.Progress.CurrentFindNumber <= 0) return;
            Debug.Log(gameFactoryTrigger.transform.position);
            Vector3 targetDirection = (gameFactoryTrigger.transform.position - _targetPosition).normalized;
            Vector3 newPosition = targetDirection *_cameraTransform.position.magnitude;
            _cameraTransform.position = newPosition;
            _cameraTransform.LookAt(_targetPosition);
            _playerProgressService.Progress.ChangeFindNumberQuantity(1);
        }
    }
}