namespace _Project.Scripts.Services.ShopService
{
    public interface IShopService
    {
        void Buy(string iD);
        void Consume(string productIdOrTag);
        void FetchPlayerPurchases();
    }
}