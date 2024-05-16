using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Services.WindowsService;
using _Project.Scripts.UI.Factories;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM.State
{
    public class PictureChooseState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IWindowsService _windowsService;
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;

        public PictureChooseState(IGameStateMachine gameStateMachine, IWindowsService windowsService, IUIFactory uiFactory, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _windowsService = windowsService;
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _uiFactory.Cleanup();
            _gameFactory.Cleanup();
            _windowsService.OpenWindow(WindowID.ChoosePicture);
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, PictureChooseState>
        {
        }
    }
}