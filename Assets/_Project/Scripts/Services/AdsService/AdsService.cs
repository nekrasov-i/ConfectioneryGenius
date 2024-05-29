using System;
using _Project.Scripts.Services.SoundAndMusicService;
using GamePush;

namespace _Project.Scripts.Services.AdsService
{
    public class AdsService : IAdsService
    {
        private readonly IGameSound _gameSound;
        public event Action RewardedVideoReady;
        public bool IsRewardedVideoReady { get; }

        public AdsService(IGameSound gameSound)
        {
            _gameSound = gameSound;
        }

        public void ShowShowFullscreen(Action<bool> closeWinMenu)
        {
            if (GP_Ads.IsFullscreenAvailable())
            {
                _gameSound.StopMusic();
                GP_Ads.ShowFullscreen(null, closeWinMenu);
            }
            else
                closeWinMenu?.Invoke(false);
        }
    }
}