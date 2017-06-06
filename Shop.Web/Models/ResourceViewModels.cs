using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
        public class ResourceViewModel
        {
            public int IdResource { get; set; }
            [DisplayName("Nazwa")]
            public string Name { get; set; }
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DisplayName("Data Wydania")]
            public DateTime ReleaseDate { get; set; }
            [DisplayName("Cena")]
            public decimal Price { get; set; }
            [DisplayName("Autor")]
            public string NameOfAuthor { get; set; }
            [DisplayName("Wydawnictwo")]
            public string PublishingHouseName { get; set; }
        }
}