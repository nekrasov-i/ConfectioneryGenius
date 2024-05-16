using System;
using _Project.Scripts.Services.PlayerProgressService;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace _Project.Scripts.UI.HUD
{
    public class BrushSizeButton : MonoBehaviour
    {
        [SerializeField] private BrushSizeButton _brushSizeButton;
        [SerializeField] private PanelController _panelController;
        [SerializeField] [Range(0, 1)] private int _brushIndex;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Sprite _spriteDown;
        private IPlayerProgressService _playerProgressService;

        public event Action OnPushButton;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }

        private void OnEnable()
        {
            _brushSizeButton.OnPushButton += OtherButtonPressed;
            _playerProgressService.Progress.BrushBonusOver += OnBonusOver;
        }

        private void OnDisable()
        {
            _brushSizeButton.OnPushButton -= OtherButtonPressed;
            _playerProgressService.Progress.BrushBonusOver -= OnBonusOver;
        }

        private void OnBonusOver() =>
            _image.sprite = _brushIndex == 0 ? _spriteDown : _sprite;

        private void OtherButtonPressed() =>
            _image.sprite = _sprite;

        public void PushButton()
        {
            if (_playerProgressService.Progress.CurrentPaintBrush <= 0) 
                return;
            _panelController.SetBrushSize(_brushIndex);
            _image.sprite = _spriteDown;
            OnPushButton?.Invoke();
        }
    }
}