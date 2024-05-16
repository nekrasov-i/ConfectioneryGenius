using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.Interface
{
    public class InterfaceController : MonoBehaviour
    {
        [SerializeField] private GameObject _canvas;
        [SerializeField] private Camera _camera;

        public GameObject Canvas => _canvas;

        public Camera Camera => _camera;

        public class Factory : PlaceholderFactory<InterfaceController>
        {
            
        }
    }
}