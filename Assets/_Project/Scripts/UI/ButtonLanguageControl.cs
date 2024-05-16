using _Project.Scripts.Services.PlayerProgressService;
using GamePush;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
    public class ButtonLanguageControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _buttonImage;
        [SerializeField] private Sprite _ENGButtonImage;
        [SerializeField] private Sprite _ENGButtonImageDown;
        [SerializeField] private Sprite _RUSButtonImage;
        [SerializeField] private Sprite _RUSButtonImageDown;
        [SerializeField] private Sprite _TURButtonImage;
        [SerializeField] private Sprite _TURButtonImageDown;
        
        private IPlayerProgressService _playerProgressService;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }

        private void Awake()
        {
            ChangeButtonSpriteMouseExit();
        }

        public void OnPointerEnter(PointerEventData eventData) => 
            ChangeButtonSpriteMouseOver();

        public void OnPointerExit(PointerEventData eventData) => 
            ChangeButtonSpriteMouseExit();

        private void ChangeButtonSpriteMouseExit()
        {
            switch (_playerProgressService.Progress.Language)
            {
                case Language.Turkish:
                    _buttonImage.sprite = _TURButtonImage;
                    break;
                case Language.Russian:
                    _buttonImage.sprite = _RUSButtonImage;
                    break;
                default:
                    _buttonImage.sprite = _ENGButtonImage;
                    break;
            }
        }

        private void ChangeButtonSpriteMouseOver()
        {
            switch (_playerProgressService.Progress.Language)
            {
                case Language.Turkish:
                    _buttonImage.sprite = _TURButtonImageDown;
                    break;
                case Language.Russian:
                    _buttonImage.sprite = _RUSButtonImageDown;
                    break;
                default:
                    _buttonImage.sprite = _ENGButtonImageDown;
                    break;
            }
        }
    }
}