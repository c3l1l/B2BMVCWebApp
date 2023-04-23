using Core.Helpers;
using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class OrderNumberService : IOrderNumberService
    {
        private readonly IOrderService _orderService;

        public OrderNumberService(IOrderService orderService)
        {
            _orderService = orderService;
        }

     
        public async Task<string> Generate()
        {
            var order = await _orderService.GetLastOrder();
            if (order != null)
            {
                var orderNumber = order.OrderNumber;
                string value = order.OrderNumber.Substring(2, orderNumber.Length - 2);
                int newNumber = Int32.Parse(value) + 1;
                var newOrderNumber = "ON";
                for (int i = 0; i < 18-newNumber.ToString().Length; i++)
                {
                    newOrderNumber += "0";
                }
               newOrderNumber += newNumber.ToString();
                return newOrderNumber;
            }
            return "ON000000000000000001";
        }
    }
}
