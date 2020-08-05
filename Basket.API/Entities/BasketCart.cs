using System.Collections.Generic;
using System.Linq;

namespace Basket.API.Entities
{
    public class BasketCart
    {
        public BasketCart()
        {

        }
        public BasketCart(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();

        //calculate total cart price

        public decimal Total => Items.Sum(x => (x.Price * x.Quantity));
    }
}
