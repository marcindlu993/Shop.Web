using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Shop.Web.Models
{
    public class ResourceFullAPI
    {
        public int IdResource { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string NameAuthor { get; set; }
        public string NamePublishingHouse { get; set; }
        public string NameTypeResource { get; set; }
        public bool SuperBargain { get; set; }
    }
}