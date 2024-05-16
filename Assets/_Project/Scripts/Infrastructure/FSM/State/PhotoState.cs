using _Project.Scripts.GamePlay.CameraСontroll;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.UI.JewelleryPanel;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM.State
{
    public class PhotoState: IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly Vector3 _cameraStartPosition = new Vector3(-25f, 20f, 0);
        private readonly Vector3 _cameraStartEulerAngles = new Vector3(35f, 90f, 0f);
        private JewelleryPanelController _photoPanel;

        public PhotoState(IGameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }
        public void Exit()
        {
            GameObject.Destroy(_photoPanel.gameObject);
            Camera.main.GetComponent<PhotoController>().Initialise(null);
        }

        public void Enter()
        {
            Camera.main.gameObject.transform.position = _cameraStartPosition;
            Camera.main.gameObject.transform.eulerAngles = _cameraStartEulerAngles;
            _photoPanel = _gameFactory.CreatePhotoPanel();
            Camera.main.GetComponent<PhotoController>().Initialise(_photoPanel.GetComponent<JewelleryPanelController>());
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, PhotoState> { }
    }
}