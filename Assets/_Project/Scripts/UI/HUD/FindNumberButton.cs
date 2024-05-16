using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.UI.HUD
{
    public class FindNumberButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private PanelController _panelController;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _findNumberSprite;
        [SerializeField] private Sprite _findNumberSpriteDown; 
        public void FindNumber() => 
            _panelController.FindNumber();

        public void OnPointerEnter(PointerEventData eventData)
        {
            _image.sprite = _findNumberSpriteDown;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _image.sprite = _findNumberSprite;
        }
    }
}