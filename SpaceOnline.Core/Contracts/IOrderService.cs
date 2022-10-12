using SpaceOnline.Core.Models;
using SpaceOnline.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceOnline.Core.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(Order baseOrder, List<CartItemVM> cartItems);
        List<Order> GetOrdersList();
        Order GetOrder(string Id);
        void UpdateOrder(Order updatedOrder);
    }
}