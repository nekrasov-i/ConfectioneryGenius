using System;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.SoundAndMusicService;
using GamePush;
using UnityEngine;

namespace _Project.Scripts.Services.AdsService
{
    public class AdsService : IAdsService
    {
        private readonly IPlayerProgressService _playerProgressService;
        private readonly IGameSound _gameSound;
        public event Action RewardedVideoReady;
        public bool IsRewardedVideoReady { get; }

        public AdsService(IPlayerProgressService playerProgressService, IGameSound gameSound)
        {
            _playerProgressService = playerProgressService;
            _gameSound = gameSound;
        }

        public void ShowRewardedVideo(Action onVideoFinished)
        {
            Debug.LogWarning("Showing of ads isn't implemented yet");
        }

        public void ShowShowFullscreen(Action<bool> closeWinMenu)
        {
            if (IsDisableAverts()) return;
            if (GP_Ads.IsFullscreenAvailable())
            {
                _gameSound.StopMusic();
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