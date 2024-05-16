using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.StaticData.UIText;
using GamePush;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.Training
{
    public class TextLanguageControl : MonoBehaviour
    {
        [SerializeField] private UIID _uiID;
        [SerializeField] private TMP_Text _textLanguage;
        private IPlayerProgressService _playerProgressService;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _playerProgressService = playerProgressService;
        }

        private void Awake()
        {
            switch (_playerProgressService.Progress.Language)
            {
                case Language.Turkish:
                    _textLanguage.text = _staticDataService.ForUIData(_uiID).TurText;
                    break;
                case Language.Russian:
                    _textLanguage.text = _staticDataService.ForUIData(_uiID).RusText;
                    break;
                default:
                    _textLanguage.text = _staticDataService.ForUIData(_uiID).EngText;
                    break;
            }
        }
    }
}