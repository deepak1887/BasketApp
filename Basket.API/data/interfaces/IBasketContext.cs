using StackExchange.Redis;

namespace Basket.API.data.interfaces
{
    public interface IBasketContext
    {
        IDatabase Redis { get; }
    }
}
