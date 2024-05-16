using _Project.Scripts.Services.WindowsService;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM.State
{
    public class GameMenuState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IWindowsService _windowsService;

        public GameMenuState(IGameStateMachine gameStateMachine, IWindowsService windowsService)
        {
            _gameStateMachine = gameStateMachine;
            _windowsService = windowsService;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _windowsService.OpenWindow(WindowID.GameMenu);
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameMenuState>
        {
        }
    }
}