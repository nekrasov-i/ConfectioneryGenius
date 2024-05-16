using System;
using System.Collections.Generic;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.SoundAndMusicService;
using _Project.Scripts.StaticData.Levels;
using GamePush;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.HUD
{
    public class PanelController: MonoBehaviour
    {
        [SerializeField] private GameObject _content;
        [SerializeField] private GameObject _colorTemplate;
        [SerializeField] private TMP_Text _quantityPaintBrush;
        [SerializeField] private TMP_Text _quantityFindNumber;
        [SerializeField] private GameObject _joystick;
        [SerializeField] private GameObject _arrows;

        private List<SetBrushColour> _brushColours = new List<SetBrushColour>();
        private IPlayerProgressService _playerProgressService;
        private IGameSound _gameSound;

        public event Action<int, Material> BrushChanged;
        public event Action<int> BrushSizeChanged;
        public event Action FindNumberPressed;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService, IGameSound gameSound)
        {
            _gameSound = gameSound;
            _playerProgressService = playerProgressService;
        }
        public void Initialise(PictureConfig pictureConfig)
        {
            foreach (Material material in pictureConfig.PictureMaterials)
            {
                GameObject color = Instantiate(_colorTemplate, _content.transform);
                color.GetComponent<Image>().color = material.color;
                _brushColours.Add(color.GetComponent<SetBrushColour>());
                SetBrushColour setBrushColour = color.GetComponent<SetBrushColour>();
                setBrushColour.Initialize(this, material, pictureConfig.PictureMaterials.IndexOf(material));
            }

            _playerProgressService.Progress.FindNumberChanged += UpdateQuantity;
            _playerProgressService.Progress.PaintBrushChanged += UpdateQuantity;
            UpdateQuantity();
            if (GP_Device.IsMobile())
            {
                _joystick.gameObject.SetActive(true);
                _arrows.gameObject.SetActive(true);
            }
        }

        private void UpdateQuantity()
        {
            _quantityPaintBrush.text = _playerProgressService.Progress.CurrentPaintBrush.ToString();
            _quantityFindNumber.text = _playerProgressService.Progress.CurrentFindNumber.ToString();
        }

        public void PlaySound() => 
            _gameSound.PlaySound();
        public void SetBrushColor(int brushIndex, Material material) => 
            BrushChanged?.Invoke(brushIndex, material);

        public void SetBrushSize(int brushSize) => 
            BrushSizeChanged?.Invoke(brushSize);
        
        public void FindNumber() => 
            FindNumberPressed?.Invoke();

        public void ChangeColorButton(int index)
        {
            foreach (SetBrushColour brushColour in _brushColours) 
                brushColour.SetButton(index);
        }
    }
}