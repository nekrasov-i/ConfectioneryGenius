using _Project.Scripts.Services.PlayerProgressService;
using GamePush;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.ChoosePicture
{
    public class ImageLanguageControl : MonoBehaviour
    {
        [SerializeField] private Image _settingsImage;
        [SerializeField] private Sprite _settingsRus;
        [SerializeField] private Sprite _settingsEng;
        [SerializeField] private Sprite _settingsTur;
        private IPlayerProgressService _playerProgressService;

        [Inject]
        public void Construct(IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }

        private void Awake() => 
            ChooseLanguage(_playerProgressService.Progress.Language);

        private void ChooseLanguage(Language language)
        {
            switch (language)
            {
                case Language.Russian:
                    _settingsImage.sprite = _settingsRus;
                    break;
                case Language.English:
                    _settingsImage.sprite = _settingsEng;
                    break;
                case Language.Turkish:
                    _settingsImage.sprite = _settingsTur;
                    break;
            }
            //_settingsImage.SetNativeSize();
        }
    }
}