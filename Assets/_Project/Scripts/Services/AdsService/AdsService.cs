using System;
using _Project.Scripts.Services.PlayerProgressService;
using GamePush;
using UnityEngine;

namespace _Project.Scripts.Services.AdsService
{
    public class AdsService : IAdsService
    {
        private readonly IPlayerProgressService _playerProgressService;
        public event Action RewardedVideoReady;
        public bool IsRewardedVideoReady { get; }

        public AdsService(IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }

        public void ShowRewardedVideo(Action onVideoFinished)
        {
            Debug.LogWarning("Showing of ads isn't implemented yet");
        }

        public void ShowShowFullscreen(Action<bool> closeWinMenu)
        {
            if (IsDisableAverts()) return;
            Debug.Log("проверяем доступность рекламы");
            if (GP_Ads.IsFullscreenAvailable())
            {
                Debug.Log("показываем рекламу");
                GP_Ads.ShowFullscreen(null, closeWinMenu);
            }
            else
                closeWinMenu?.Invoke(false);
        }

        private bool IsDisableAverts()
        {
            if (_playerProgressService.Progress.DisableAdverts) return true;
            return false;
        }
    }
}