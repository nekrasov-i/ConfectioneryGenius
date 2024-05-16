using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Infrastructure.FSM.State;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.JewelleryPanel
{
    [RequireComponent(typeof(Button))]
    public class EnterChoosePictureStateButton : MonoBehaviour
    {
        private Button _button;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(() => _gameStateMachine.Enter<PictureChooseState>());
        }
    }
}