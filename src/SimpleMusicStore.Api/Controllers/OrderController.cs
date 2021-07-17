using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Models.View;

namespace SimpleMusicStore.Api.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orders;

        public OrderController(IOrderService orders)
            : base()
        {
            _orders = orders;
        }

        public Task AddToCart(int id)
        {
            return _orders.AddToCart(id);
        }

        public Task RemoveFromCart(int id)
        {
            return _orders.RemoveFromCart(id);
        }

        public Task IncreaseQuantity(int id)
        {
            return _orders.IncreaseQuantity(id);
        }

        public Task DecreaseQuantity(int id)
        {
            return _orders.DecreaseQuantity(id);
        }

        public Task Complete(int addressId)
        {
            return _orders.Complete(addressId);
        }

        public Task<IEnumerable<CartItem>> Cart()
        {
            return _orders.CurrentCartState();
        }

        public Task<OrderView> Details(int id)
        {
            return _orders.Find(id);
        }
    }
}