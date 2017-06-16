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

        public void AddItem(Resource cartResource, int quantity, string media)
        {
            CartPosition cartPosition = cartPositions.Where(x => x.Resource.IdResource == cartResource.IdResource && x.Media == media).FirstOrDefault();
            if (cartPosition == null)
            {
                cartPositions.Add(new CartPosition { Resource = cartResource, Quantity = quantity, Media = media });
            }
            else
            {
                cartPosition.Quantity += quantity;
            }
        }

        public decimal SumValue()
        {
            return cartPositions.Sum(e => e.Resource.Price * e.Quantity);
        }

        public IEnumerable<CartPosition> Positions
        {
            get { return cartPositions; }
        }

        public int CounterResources()
        {
            return cartPositions.Sum(e => e.Quantity);
        }
        
    }

    public class CartPosition
    {
        public Resource Resource { get; set; }
        public int Quantity { get; set; }
        public string Media { get; set; }
    }

}