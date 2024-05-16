using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Project.Scripts.UI.HUD
{
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        [SerializeField] private Sprite _SoundOn;
        [SerializeField] private Sprite _SoundOff;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private bool _isMusic;
        
        private bool _isSoundOn = true;
        private const string _SFXVolume = "SFXVolume";
        private const string _MusicVolume = "MusicVolume";

        private void Awake()
        {
            _button.onClick.AddListener(ToggleSound);
        }

        private void ToggleSound()
        {
            if (_isSoundOn)
            {
                _audioMixer.SetFloat(_isMusic ? _MusicVolume : _SFXVolume, -80f);
                _isSoundOn = false;
                _image.sprite = _SoundOff;
            }
            else
            {
                _audioMixer.SetFloat(_isMusic ? _MusicVolume : _SFXVolume, 0f);
                _isSoundOn = true;
                _image.sprite = _SoundOn;
                
            }
        }
    }
}