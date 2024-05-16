using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.JewelleryPanel
{
    public class TakeScreenShot : MonoBehaviour
    {
        [SerializeField] GameObject _panel;
        [SerializeField] GameObject _photoButten;
        [SerializeField] GameObject _exitButton;
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(TakeMyScreenShot);
        }

        private void TakeMyScreenShot()
        {
            SetActive(false);
            ScreenCapture.CaptureScreenshot("Screenshot -"+ DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", 4);
            SetActive(true);
        }

        private void SetActive(bool value)
        {
            _panel.SetActive(value);
            _photoButten.SetActive(value);
            _exitButton.SetActive(value);
        }
    }
}