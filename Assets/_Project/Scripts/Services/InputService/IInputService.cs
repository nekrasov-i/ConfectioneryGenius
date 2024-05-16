using UnityEngine;

namespace _Project.Scripts.Services.InputService
{
    public interface IInputService
    {
        Vector2 GetRotationInput();
        float GetZoomInput();
        bool GetInteractInput(out Vector3 interactInput);
    }
}