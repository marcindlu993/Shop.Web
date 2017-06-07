using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class CartViewModels
    {
        public class AddToCartViewModel
        {
            [DisplayName("Tytuł")]
            [ReadOnly(true)]
            public string Name { get; set; }
            [DisplayName("Nośnik")]
            public string MediaType { get; set; }
            [DisplayName("Ilość")]
            [Range(1,999,ErrorMessage = "Proszę wpisać wartość z przedziału 1 - 999")]
            public int Quantity { get; set; }
        }

        public class MyCartViewModel
        {
            [DisplayName("Tytuł")]
            public string Name { get; set; }
            [DisplayName("Nośnik")]
            public string Media { get; set; }
            [DisplayName("Ilość")]
            public int Quantity { get; set; }
            [DisplayName("Cena")]
            public decimal Price { get; set; }
        }
    }
}