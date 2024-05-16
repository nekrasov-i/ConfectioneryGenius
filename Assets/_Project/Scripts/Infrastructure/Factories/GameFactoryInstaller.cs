using _Project.Scripts.UI.HUD;
using _Project.Scripts.UI.JewelleryPanel;
using Zenject;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class GameFactoryInstaller : Installer<GameFactoryInstaller>
    {
        public override void InstallBindings()
        {
            // bind sub-factories here
            Container.BindFactory<HUDRoot, HUDRoot.Factory>().FromComponentInNewPrefabResource(InfrastructureAssetPath.HUDRoot);
            Container.BindFactory<JewelleryPanelController, JewelleryPanelController.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.JewelleryPanel);
        
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }
    }
}