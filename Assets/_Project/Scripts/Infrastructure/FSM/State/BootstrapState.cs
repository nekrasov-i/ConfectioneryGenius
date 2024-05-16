using _Project.Scripts.Services.AdsService;
using _Project.Scripts.Services.StaticDataService;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM.State
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine gameStateMachine;
        private readonly IStaticDataService staticDataService;

        public BootstrapState(IGameStateMachine gameStateMachine,
            IStaticDataService staticDataService)
        {
            Debug.Log("BootstrapState constructor");
            this.staticDataService = staticDataService;
            this.gameStateMachine = gameStateMachine;
            this.staticDataService = staticDataService;
        }

        public void Enter()
        {
            Debug.Log("BootstrapState Enter");
            
            InitServices();
            gameStateMachine.Enter<LoadPlayerProgressState>();
        }

        private void InitServices()
        {
            staticDataService.Initialize();
        }

        public void Exit()
        {
            Debug.Log("BootstrapState Exit");
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}