using _Project.Scripts.Services.SoundAndMusicService;
using _Project.Scripts.UI.Factories;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM.State
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IUIFactory _uiFactory;
        private readonly IGameSound _gameSound;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain, IUIFactory uiFactory, IGameSound gameSound)
        {
            _gameSound = gameSound;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
            _gameSound.PlayMusic();
        }

        private void OnLoaded()
        {
            _uiFactory.CreateInterface();
            _gameStateMachine.Enter<GameMenuState>();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}