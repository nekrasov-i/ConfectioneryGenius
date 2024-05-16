using _Project.Scripts.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.JewelleryPanel
{
    public class JewelleryPanelController:MonoBehaviour
    {
        [SerializeField] private GameObject _content;
        [SerializeField] private GameObject _jewelleryTemplate;
        
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Initialize() => 
            _gameFactory.CreateJewelleryOnPanel(_content,  _jewelleryTemplate);

        public class Factory : PlaceholderFactory<JewelleryPanelController>
        {
            
        }
    }
}