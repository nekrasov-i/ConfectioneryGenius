using System;

namespace _Project.Scripts.Services.AdsService
{
    public interface IAdsService
    {
        event Action RewardedVideoReady;
        bool IsRewardedVideoReady { get; }
        void ShowRewardedVideo(Action onVideoFinished);
        void ShowShowFullscreen(Action<bool> closeWinMenu);
    }
}