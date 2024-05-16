using System;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.StaticData.Jewellerys;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.JewelleryPanel
{
    public class JewelleryButton : MonoBehaviour
    {
        [SerializeField] private Image _jewelleryTemplate;
        
        private JewelleryID _jewelleryID;
        private IGameFactory _gameFactory;

        public JewelleryID ID => _jewelleryID;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void SetID(JewelleryID jewelleryID) =>
            _jewelleryID = jewelleryID;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Spawn);
        }

        private void Spawn() => 
            _gameFactory.CreateJewellery(_jewelleryID, gameObject.GetComponentInParent<Canvas>(), _jewelleryTemplate);
    }
}