using _Project.Scripts.Infrastructure;
using _Project.Scripts.UI.Interface;
using Zenject;

namespace _Project.Scripts.UI.Factories
{
    public class UIFactoryInstaller : Installer<UIFactoryInstaller>
    {
        public override void InstallBindings()
        {
            // bind ui sub-factories here
            Container.BindFactory<InterfaceController, InterfaceController.Factory>().FromComponentInNewPrefabResource(InfrastructureAssetPath.Interface);
            
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }
    }
}