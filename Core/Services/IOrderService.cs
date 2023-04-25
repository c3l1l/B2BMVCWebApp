using Core.Models;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IOrderService:IGenericService<Order>
    {
        Task<Order> GetLastOrder();
        Task SaveOrderWithOrderItemsAsync(Order order);
        Task<Order> CheckAndCreateOrder(OrderVM orderVM);
        Task<List<Order>> GetOrdersWithUser();
        Task<Order> GetOrderWithOrderItemsByOrderId(int orderId);
        Task<Order> ChangeOrderStatus(Order order);
        Task<Order> CancelOrder(Order order);
       

    }
}
