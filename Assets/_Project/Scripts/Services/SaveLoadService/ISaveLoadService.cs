using _Project.Scripts.Data;

namespace _Project.Scripts.Services.SaveLoadService
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}