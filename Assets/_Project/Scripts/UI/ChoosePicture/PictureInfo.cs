using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.ChoosePicture
{
    public class PictureInfo: MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _name;
        
        private int _pictureId;

        public void SetPictureId(int pictureId)
        {
            _pictureId = pictureId;
        }

        public int PictureId => _pictureId;

        public void Initialize(int pictureId, Sprite icon , string name)
        {
            _name.text = name;
            _pictureId = pictureId;
            _image.sprite = icon;
        }
    }
}