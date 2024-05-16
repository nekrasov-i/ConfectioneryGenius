using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Infrastructure.Factories;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Scripts.UI.Training
{
    public class ManageLearningPanel : MonoBehaviour
    {
        [FormerlySerializedAs("_text1")] [SerializeField]
        private List<TMP_Text> _text;

        private int _current = 0;
        private bool _isButtonPressed = false;

        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            if (_gameFactory.CurrentPictureID != 0)
                gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.anyKeyDown && !_isButtonPressed)
            {
                _isButtonPressed = true;
                _text[_current].gameObject.SetActive(false);
                _current++;

                if (_current <= _text.Count - 1)
                {
                    _text[_current].gameObject.SetActive(true);
                    StartCoroutine(Delay());
                }
                else
                    gameObject.SetActive(false);
            }
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.5f);
            _isButtonPressed = false;
        }
    }
}