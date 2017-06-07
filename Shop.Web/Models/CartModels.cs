using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class Cart
    {
        private List<CartPosition> cartPositions = new List<CartPosition>();

        public void AddItem(CartResource cartResource, int quantity, string media)
        {
            CartPosition cartPosition = cartPositions.Where(x => x.CartResource.IdResource == cartResource.IdResource).FirstOrDefault();
            if (cartPosition == null)
            {
                cartPositions.Add(new CartPosition { CartResource = cartResource, Quantity = quantity, Media = media });
            }
            else
            {
                cartPosition.Quantity += quantity;
            }
        }

        public decimal SumValue()
        {
            return cartPositions.Sum(e => e.CartResource.Price * e.Quantity);
        }
        
    }

    public class CartPosition
    {
        public CartResource CartResource { get; set; }
        public int Quantity { get; set; }
        public string Media { get; set; }
    }

    public class CartResource
    {
        public int IdResource { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}