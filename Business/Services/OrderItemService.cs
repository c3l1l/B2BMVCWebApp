using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class OrderItemService : GenericService<OrderItem>, IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IBasketItemRepository _basketItemRepository;

        private readonly IMapper _mapper;
        public OrderItemService(IGenericRepository<OrderItem> repository, IUnitOfWork unitOfWork, IOrderItemRepository orderItemRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }
        public async Task OrderItemsFindAndSave()
        {

        }
    }
}
