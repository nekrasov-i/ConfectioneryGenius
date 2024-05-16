using UnityEngine;

namespace _Project.Scripts.Services.SoundAndMusicService
{
    public class GameSound: MonoBehaviour, IGameSound
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _soundSource;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void PlayMusic() => 
            _musicSource.Play();
        
        public void StopMusic() =>
            _musicSource.Stop();
        
        public void PlaySound() =>
            _soundSource.Play();
    }
}