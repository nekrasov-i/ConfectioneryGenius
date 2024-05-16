using _Project.Scripts.Infrastructure.FSM.State;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadPlayerProgressState, LoadPlayerProgressState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadLevelState, LoadLevelState.Factory>();
            Container.BindFactory<IGameStateMachine, GameLoopState, GameLoopState.Factory>();
            Container.BindFactory<IGameStateMachine, GameMenuState, GameMenuState.Factory>();
            Container.BindFactory<IGameStateMachine, PictureDoneState, PictureDoneState.Factory>();
            Container.BindFactory<IGameStateMachine, PictureChooseState, PictureChooseState.Factory>();
            Container.BindFactory<IGameStateMachine, PhotoState, PhotoState.Factory>();
            
            

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        
        }
    }
}