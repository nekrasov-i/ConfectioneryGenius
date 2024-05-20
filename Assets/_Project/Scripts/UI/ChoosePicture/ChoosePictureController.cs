using System.Collections.Generic;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Infrastructure.FSM.State;
using _Project.Scripts.Services.SoundAndMusicService;
using _Project.Scripts.UI.Factories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.ChoosePicture
{
    public class ChoosePictureController : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonTemplate;
        [SerializeField] private GameObject _content;
        
        private List<GameObject> _buttons;
        private IGameFactory _gameFactory;
        private IGameStateMachine _gameStateMachine;
        private IUIFactory _uiFactory;
        private IGameSound _gameSound;

        [Inject]
        private void Construct(IGameFactory gameFactory, IGameStateMachine gameStateMachine,
            IUIFactory uiFactory, IGameSound gameSound)
        {
            _gameSound = gameSound;
            _uiFactory = uiFactory;
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _buttons = _uiFactory.Buttons;
        }

        private void Start()
        {
            _uiFactory.CreatePictureButton(_buttonTemplate, _content);
            foreach (GameObject button in _buttons)
                button.GetComponent<Button>().onClick
                    .AddListener(() => ChoosePicture(button.GetComponent<PictureInfo>()));
        }

        private void ChoosePicture(PictureInfo pictureInfo)
        {
            _gameSound.PlaySound();
            _gameFactory.CreatePicture(pictureInfo.PictureId);
            _gameStateMachine.Enter<GameLoopState>();
            Destroy(gameObject);
        }
    }
}