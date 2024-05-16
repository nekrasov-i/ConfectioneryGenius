using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Infrastructure.FSM.State;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine gameStateMachine;

        [Inject]
        void Construct(IGameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }
        
        private void Start()
        {
            gameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }

        public class Factory : PlaceholderFactory<GameBootstrapper>
        {
        }
    }
}