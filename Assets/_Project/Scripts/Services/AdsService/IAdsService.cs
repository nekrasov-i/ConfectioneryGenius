using System;

namespace _Project.Scripts.Services.AdsService
{
    public interface IAdsService
    {
        void ShowShowFullscreen(Action<bool> closeWinMenu);
    }
}