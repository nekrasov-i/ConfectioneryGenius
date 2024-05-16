using _Project.Scripts.GamePlay.CameraСontroll;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.UI.HUD;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM.State
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        
        private readonly Vector3 _cameraStartPosition = new Vector3(-25f, 20f, 0);
        private readonly Vector3 _cameraStartEulerAngles = new Vector3(35f, 90f, 0f);
        
        private GameObject _hudRoot;
        

        public GameLoopState(IGameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        public void Exit()
        {
            Camera.main.GetComponent<PlayerController>().Initialise(null);
            Object.Destroy(_hudRoot);
        }

        public void Enter()
        {
            _hudRoot = _gameFactory.CreateHUD().gameObject;
            Camera.main.GetComponent<PlayerController>().Initialise(_hudRoot.GetComponent<PanelController>());
            Camera.main.gameObject.transform.position = _cameraStartPosition;
            Camera.main.gameObject.transform.eulerAngles = _cameraStartEulerAngles;
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameLoopState>
        {
        }
    }
}