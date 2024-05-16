using System;
using System.Collections.Generic;
using GamePush;
using UnityEngine;

namespace _Project.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        [SerializeField] private List<int> _pictureIds;
        [SerializeField] private int _currentPaintBrush;
        [SerializeField] private int _currentFindNumber;
        [SerializeField] private bool _disableAdverts;
        [SerializeField] private Language _language;
        public event Action PaintBrushChanged;
        public event Action FindNumberChanged;
        public event Action BrushBonusOver;
        public event Action FindNumberBonusOver;
        public event Action LanguageChanged;

        public PlayerProgress()
        {
            _pictureIds = new List<int>();
            _currentPaintBrush = 60;
            _currentFindNumber = 60;
            _language = GP_Language.Current();
        }

        public int CurrentPaintBrush => _currentPaintBrush;

        public int CurrentFindNumber => _currentFindNumber;

        public bool DisableAdverts => _disableAdverts;

        public Language Language => _language;

        public List<int> PictureIds => _pictureIds;

        public void SetLanguage(Language language)
        {
            _language = language;
            LanguageChanged?.Invoke();
        }

        public void PictureDone(int currentPictureID, int brushBonus, int findNumberBonus)
        {
            if (_pictureIds.Contains(currentPictureID)) return;
            _pictureIds.Add(currentPictureID);
            AddPaintBrushQuantity(brushBonus);
            AddFindNumberQuantity(findNumberBonus);
        }

        public void SpendPaintBrushQuantity(int value)
        {
            _currentPaintBrush = CurrentPaintBrush - value;
            if (CurrentPaintBrush <= 0)
            {
                _currentPaintBrush = 0;
                BrushBonusOver?.Invoke();
            }

            PaintBrushChanged?.Invoke();
        }

        public void ChangeFindNumberQuantity(int value)
        {
            _currentFindNumber = CurrentFindNumber - value;
            if (CurrentFindNumber < 0)
            {
                _currentFindNumber = 0;
                FindNumberBonusOver?.Invoke();
            }

            FindNumberChanged?.Invoke();
        }

        public void SetDisableAdverts() =>
            _disableAdverts = true;

        public void AddPaintBrushQuantity(int volume)
        {
            _currentPaintBrush += volume;
            PaintBrushChanged?.Invoke();
        }

        public void AddFindNumberQuantity(int volume)
        {
            _currentFindNumber += volume;
            FindNumberChanged?.Invoke();
        }
    }
}