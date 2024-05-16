using System.Collections.Generic;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.SaveLoadService;
using _Project.Scripts.Services.StaticDataService;
using GamePush;
using UnityEngine;

namespace _Project.Scripts.Services.ShopService
{
    public class ShopService : IShopService
    {
        private readonly IPlayerProgressService _playerProgressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IStaticDataService _staticDataService;

        public ShopService(IPlayerProgressService playerProgressService, ISaveLoadService saveLoadService, IStaticDataService staticDataService)
        {
            _playerProgressService = playerProgressService;
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;
        }

        public void FetchPlayerPurchases()
        {
            GP_Payments.OnFetchPlayerPurchases += OnFetchPlayerPurchases;
            GP_Payments.Fetch();
            GP_Payments.OnFetchPlayerPurchases -= OnFetchPlayerPurchases;
        }

        public void Buy(string iD)
        {
            GP_Payments.Purchase(iD, OnPurchaseSuccess, OnPurchaseError);
        }

        public void Consume(string productIdOrTag) => 
            GP_Payments.Consume(productIdOrTag, OnConsumeSuccess, OnConsumeError);

        private void OnFetchPlayerPurchases(List<FetchPlayerPurchases> purchases)
        {
            foreach (FetchPlayerPurchases purchase in purchases)
            {
                OnPurchaseSuccess(purchase.productId.ToString());
            }
        }

        private void OnPurchaseSuccess(string productIdOrTag)
        {
            Debug.Log("PURCHASE: SUCCESS: " + productIdOrTag);
            switch (productIdOrTag)
            {
                case "1":
                    DisableAdverts();
                    break;
                default:
                    Consume(productIdOrTag);
                    break;
            }
        }

        private void DisableAdverts()
        {
            _playerProgressService.Progress.SetDisableAdverts();
            _saveLoadService.SaveProgress();
        }

        private void OnPurchaseError() => Debug.Log("PURCHASE: ERROR");

        private void OnConsumeSuccess(string productIdOrTag)
        {
            switch (productIdOrTag)
            {
                case "2":
                    AddPaintBrush(productIdOrTag);
                    break;
                case "3":
                    AddPaintBrush(productIdOrTag);
                    break;
                case "4":
                    AddFindNumber(productIdOrTag);
                    break;
                default:
                    Debug.Log("консум удачный на фиг знает что купили");
                    break;
            }
        }

        private void AddFindNumber(string productIdOrTag)
        {
            var volume = _staticDataService.ForShopItem(productIdOrTag).Volume;
            _playerProgressService.Progress.AddFindNumberQuantity(volume);
            _saveLoadService.SaveProgress();
        }

        private void AddPaintBrush(string productIdOrTag)
        {
            var volume = _staticDataService.ForShopItem(productIdOrTag).Volume;
            _playerProgressService.Progress.AddPaintBrushQuantity(volume);
            _saveLoadService.SaveProgress();
        }

        private void OnConsumeError() => Debug.Log("CONSUME: ERROR");
    }
}