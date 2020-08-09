using FluentValidator;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.CommandHandlers
{
    public class OrderHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public void Handle(RegisterOrderCommand command)
        {
            //instancia cliente lendo do repositorio
            var customer = _customerRepository.Get(command.Customer);

            //gera novo pedido  
            var order = new Order(customer, command.DeliveryFee, command.Discount);

            //add items no pedido
            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }

            //add notificacoes do pedido no handler
            AddNotifications(order.Notifications);

            //persiste no banco
            if (IsValid())
                _orderRepository.Save(order);
        }
    }
}
