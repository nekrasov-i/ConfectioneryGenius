using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.SaveLoadService;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.Services.WindowsService;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM.State
{
    public class PictureDoneState: IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IWindowsService _windowsService;
        private readonly IPlayerProgressService _playerProgressService;
        private readonly IGameFactory _gameFactory;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IStaticDataService _staticDataService;

        public PictureDoneState(IGameStateMachine gameStateMachine, IWindowsService windowsService, IPlayerProgressService playerProgressService, IGameFactory gameFactory, ISaveLoadService saveLoadService, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _windowsService = windowsService;
            _playerProgressService = playerProgressService;
            _gameFactory = gameFactory;
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _windowsService.OpenWindow(WindowID.WinMenu);
            var picture = _staticDataService.ForPicture(_gameFactory.CurrentPictureID);
            _playerProgressService.Progress.PictureDone(_gameFactory.CurrentPictureID, picture.BrushBonus, picture.FindNumberBonus);
            _saveLoadService.SaveProgress();
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, PictureDoneState> { }
    }
}