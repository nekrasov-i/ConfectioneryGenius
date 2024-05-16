using UnityEngine;

namespace _Project.Scripts.Services.InputService
{
    public class MobileInputService: IInputService
    {
        const string horizontalrotation = "Horizontal";
        const string verticalrotation = "Vertical";
        const string MouseScrollWheel = "Mouse ScrollWheel";
        public Vector2 GetRotationInput()
        {
            float horizontalRotation = SimpleInput.GetAxis(horizontalrotation);
            float verticalRotation = SimpleInput.GetAxis(verticalrotation);
            return new Vector2(horizontalRotation, verticalRotation);
        }

        public float GetZoomInput()
        {
            return SimpleInput.GetAxis(MouseScrollWheel);
        }

        public bool GetInteractInput(out Vector3 interactInput)
        {
            if (!Input.GetMouseButton(0))
            {
                interactInput = default;
                return false;
            }

            interactInput = GetMousePosition();
            return true;
        }
        private Vector3 GetMousePosition()
        {
            return Input.mousePosition;
        }
    }
}