using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        GameBootstrapper.Factory gameBootstrapperFactory;

        [Inject]
        void Construct(GameBootstrapper.Factory bootstrapperFactory) => 
            gameBootstrapperFactory = bootstrapperFactory;

        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();
      
            if(bootstrapper != null) return;

            gameBootstrapperFactory.Create();
        }
    }
}