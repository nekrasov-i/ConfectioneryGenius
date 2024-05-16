using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.UI.ChoosePicture
{
    public class ScrollButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isPressed;

        public bool IsPressed => _isPressed;

        public void OnPointerDown(PointerEventData eventData) => 
            _isPressed = true;

        public void OnPointerUp(PointerEventData eventData) => 
            _isPressed = false;
    }
}