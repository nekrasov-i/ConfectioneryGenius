using _Project.Scripts.Services.SoundAndMusicService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.HUD
{
    public class SetBrushColour: MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Sprite _spriteDown;
        [SerializeField] private TMP_Text _indexText;
        
        private Material _material;
        private PanelController _panelController;
        private int _index;

        private void Start() => 
            _button.onClick.AddListener(BrushChanged);

        public void Initialize(PanelController panelController, Material material, int index)
        {
            _index = index;
            _indexText.text = (index+1).ToString();
            _material = material;
            _panelController = panelController;
        }

        public void SetButton(int index) => 
            _image.sprite = index == _index ? _spriteDown : _sprite;

        private void BrushChanged()
        {
            _panelController.PlaySound();
            _panelController.SetBrushColor(_index, _material);
            _panelController.ChangeColorButton(_index);
        }
    }
}