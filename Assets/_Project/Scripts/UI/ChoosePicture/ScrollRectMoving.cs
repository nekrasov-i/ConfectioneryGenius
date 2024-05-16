using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.ChoosePicture
{
    public class ScrollRectMoving : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private ScrollButton _leftButton;
        [SerializeField] private ScrollButton _rightButton;
        [SerializeField] private float _speed = 0.01f;

        private void Update()
        {
            if (_leftButton.IsPressed)
                _scrollRect.horizontalNormalizedPosition -= _speed;
            if (_rightButton.IsPressed)
                _scrollRect.horizontalNormalizedPosition += _speed;
        }
    }
}