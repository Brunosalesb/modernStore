using FluentValidator;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity
    {
        #region Constructors
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(x => x.Quantity, 1)
                .IsGreaterThan(x => x.Product.QuantityOnHand, Quantity + 1, $"Não temos tantos { product.Title } em estoque");

            Product.DecreaseQuantity(quantity);
        }
        #endregion

        #region Properties
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        #endregion

        #region Methods
        public decimal Total() => Price * Quantity;
        #endregion
    }
}
