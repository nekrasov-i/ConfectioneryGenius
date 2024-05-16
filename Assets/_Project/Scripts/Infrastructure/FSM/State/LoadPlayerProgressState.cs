using _Project.Scripts.Data;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.SaveLoadService;
using _Project.Scripts.Services.ShopService;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM.State
{
    public class LoadPlayerProgressState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IShopService _shopService;
        private readonly IPlayerProgressService _progressService;

        public LoadPlayerProgressState(IGameStateMachine gameStateMachine, IPlayerProgressService progressService, ISaveLoadService saveLoadService, IShopService shopService)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _shopService = shopService;
            _progressService = progressService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _shopService.FetchPlayerPurchases();
            _gameStateMachine.Enter<LoadLevelState, string>(InfrastructureAssetPath.StartGameScene);
        }

        

        public void Exit()
        {
            
        }

        private PlayerProgress LoadProgressOrInitNew()
        {
            _progressService.Progress = 
                _saveLoadService.LoadProgress() 
                ?? NewProgress();
            return _progressService.Progress;
        }

        private PlayerProgress NewProgress()
        {
            var progress =  new PlayerProgress();
            return progress;
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, LoadPlayerProgressState> { }
    }
}