using _Project.Scripts.Data;

namespace _Project.Scripts.Services.PlayerProgressService
{
    public interface IPlayerProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}