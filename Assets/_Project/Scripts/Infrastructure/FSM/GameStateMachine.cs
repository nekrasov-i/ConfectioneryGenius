using System;
using System.Collections.Generic;
using _Project.Scripts.Infrastructure.FSM.State;

namespace _Project.Scripts.Infrastructure.FSM
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<System.Type, IExitableState> _registeredStates;
        private IExitableState _currentState;

        public IExitableState CurrentState => _currentState;

        public GameStateMachine(
            BootstrapState.Factory bootstrapStateFactory,
            LoadPlayerProgressState.Factory loadGameSaveStateFactory,
            LoadLevelState.Factory loadLevelStateFactory, GameLoopState.Factory gameLoopStateFactory,
            GameMenuState.Factory gameMenuStateFactory, PictureDoneState.Factory pictureDoneStateFactory,
            PictureChooseState.Factory pictureChooseStateFactory, PhotoState.Factory photoStateFactory)
        {
            _registeredStates = new Dictionary<Type, IExitableState>();
            
            RegisterState(bootstrapStateFactory.Create(this));
            RegisterState(loadGameSaveStateFactory.Create(this));
            RegisterState(loadLevelStateFactory.Create(this));
            RegisterState(gameLoopStateFactory.Create(this));
            RegisterState(gameMenuStateFactory.Create(this));
            RegisterState(pictureDoneStateFactory.Create(this));
            RegisterState(pictureChooseStateFactory.Create(this));
            RegisterState(photoStateFactory.Create(this));
        }

        private void RegisterState<TState>(TState state) where TState : IExitableState =>
            _registeredStates.Add(typeof(TState), state);

        public void Enter<TState>() where TState : class, IState
        {
            TState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPaylodedState<TPayload>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            CurrentState?.Exit();
      
            TState state = GetState<TState>();
            _currentState = state;
      
            return state;
        }
    
        private TState GetState<TState>() where TState : class, IExitableState => 
            _registeredStates[typeof(TState)] as TState;
    }
}