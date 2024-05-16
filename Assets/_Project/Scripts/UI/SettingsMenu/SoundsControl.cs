using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Project.Scripts.UI.SettingsMenu
{
    public class SoundsControl : MonoBehaviour
    {
        private const string SFXVolume = "SFXVolume";
        private const string Musicvolume = "MusicVolume";
        
        [SerializeField] private Slider _vFXSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private AudioMixer _audioMixer;

        private void Awake()
        {
            _vFXSlider.onValueChanged.AddListener(OnVFXValueChanged);
            _musicSlider.onValueChanged.AddListener(OnMusicValueChanged);
        }

        private void OnMusicValueChanged(float value) => 
            _audioMixer.SetFloat(Musicvolume, Mathf.Log10(value) * 20f);

        private void OnVFXValueChanged(float value) => 
            _audioMixer.SetFloat(SFXVolume, Mathf.Log10(value) * 20f);
    }
}