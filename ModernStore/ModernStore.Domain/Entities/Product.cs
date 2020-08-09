using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Entities
{
    public class Product : Entity
    {
        #region Constructors
        //por conta do EF, as entidades precisam ter um ctor vazio(uso protected par nao ser corruptivel)
        protected Product() { }
        public Product(string title, decimal price, string image, int quantityOnHand)
        {
            Title = title;
            Price = price;
            Image = image;
            QuantityOnHand = quantityOnHand;
        }
        #endregion

        #region Properties
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public int QuantityOnHand { get; private set; }
        #endregion

        #region Methods
        public void DecreaseQuantity(int quantity) => QuantityOnHand -= quantity;
        #endregion
    }
}
