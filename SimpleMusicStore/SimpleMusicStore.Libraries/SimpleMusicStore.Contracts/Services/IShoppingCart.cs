using SimpleMusicStore.Models.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Services
{
    public interface IShoppingCart
    {
        Dictionary<int, int> Items { get; }
        Task<IEnumerable<CartItem>> CurrentState();
        Task Add(int itemId);
        Task Remove(int itemId);
        Task IncreaseQuantity(int itemId);
        Task DecreaseQuantity(int itemId);
        Task EmptyCart();
    }
}
