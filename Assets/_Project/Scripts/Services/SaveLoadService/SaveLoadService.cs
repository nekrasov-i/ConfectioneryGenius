using _Project.Scripts.Data;
using _Project.Scripts.Services.PlayerProgressService;
using GamePush;
using UnityEngine;

namespace _Project.Scripts.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PlayerProgress = "PlayerProgress";

        private readonly IPlayerProgressService _playerProgressService;

        public SaveLoadService(IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }

        
        public void SaveProgress()
        {
            GP_Player.Set(PlayerProgress, _playerProgressService.Progress.ToJson());
            GP_Player.Sync();
            #if UNITY_EDITOR
            PlayerPrefs.SetString(PlayerProgress, _playerProgressService.Progress.ToJson());
            Debug.Log(_playerProgressService.Progress.CurrentPaintBrush);
            Debug.Log("SavePlayerPrefs");
            #endif
        }

        public PlayerProgress LoadProgress()
        {
            var playerProgress = GP_Player.GetString(PlayerProgress);
            if(string.IsNullOrEmpty(playerProgress)) 
                return null;

            if (!playerProgress.Trim().StartsWith("{"))
                return null;

            var deserialized = playerProgress.ToDeserialized<PlayerProgress>();
            if (deserialized != null)
                if(deserialized.DisableAdverts) GP_Ads.CloseSticky();
            return deserialized;
        }
    }
}