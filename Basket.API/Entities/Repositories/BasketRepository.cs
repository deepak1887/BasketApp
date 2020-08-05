using Basket.API.data;
using Basket.API.data.interfaces;
using Basket.API.Entities.Repositories.interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Basket.API.Entities.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext context;

        public BasketRepository(BasketContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            return await context.Redis.KeyDeleteAsync(userName);
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            var basket = await this.context.Redis.StringGetAsync(userName);
            if (basket.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basketCart)
        {
            var updated = await context.Redis.StringSetAsync(basketCart.UserName, JsonConvert.SerializeObject(basketCart));
            if (!updated) return null;
            return await GetBasket(basketCart.UserName);
        }
    }
}
