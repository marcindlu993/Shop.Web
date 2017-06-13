using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class Resource
    {
        [Key]
        public int IdResource { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Author")]
        public int IdAuthor { get; set; }
        [ForeignKey("PublishingHouse")]
        public int IdPublishingHouse { get; set; }
        [ForeignKey("TypeResource")]
        public int IdTypeResource { get; set; }
        public Author Author { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public TypeResource TypeResource { get; set; }
        /*TypeResource:
         * 1 - Audiobooki, 2 - E-booki
         * */
        public bool SuperBargain { get; set; }
    }

    public class Author
    {
        [Key]
        public int IdAuthor { get; set; }
        public string NameAuthor { get; set; }
    }

    public class TypeResource
    {
        [Key]
        public int IdTypeResource { get; set; }
        public string NameTypeResource { get; set; }
    }

    public class PublishingHouse
    {
        [Key]
        public int IdPublishingHouse { get; set; }
        public string NamePublishingHouse { get; set; }
    }
}