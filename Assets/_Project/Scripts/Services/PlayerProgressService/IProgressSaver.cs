namespace _Project.Scripts.Services.PlayerProgressService
{
    public interface IProgressSaver : IProgressReader
    {
        void UpdateProgress(Data.PlayerProgress progress);
    }
}