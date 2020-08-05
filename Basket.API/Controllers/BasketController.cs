using Basket.API.Entities;
using Basket.API.Entities.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }

        [HttpGet]
        [Route("{userName}")]
        public async Task<IActionResult> GetBasket(string userName)
        {
            
            return Ok(await basketRepository.GetBasket(userName));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody]BasketCart basketCart)
        {
            return Ok(await basketRepository.UpdateBasket(basketCart));
        }

        [HttpDelete]
        [Route("{userName}")]
        public async Task<IActionResult> Delete(string userName)
        {
            return Ok(await basketRepository.DeleteBasket(userName));
        }

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> Checkout()
        //{
        //    return Ok(await basketRepository);
        //}

    }
}
