using _Project.Scripts.Infrastructure.Factories;
using GamePush;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.JewelleryPanel
{
    public class JewelleryPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject _content;
        [SerializeField] private GameObject _jewelleryTemplate;
        [SerializeField] private GameObject _joystick;
        [SerializeField] private GameObject _arrows;


        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Initialize()
        {
            _gameFactory.CreateJewelleryOnPanel(_content, _jewelleryTemplate);

            if (GP_Device.IsMobile())
            {
                _joystick.gameObject.SetActive(true);
                _arrows.gameObject.SetActive(true);
            }
        }

        public class Factory : PlaceholderFactory<JewelleryPanelController>
        {
        }
    }
}