using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Shop.Web.Models;
using API.Shop.Web.Models;

namespace API.Shop.Web.Controllers
{
    public class ResourcesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Resources
        public IEnumerable<ResourceFullAPI> GetResources()
        {
            List<ResourceFullAPI> resourceFullAPI = new List<ResourceFullAPI>();
            List<Resource> resource = db.Resources.ToList();
            foreach (var item in resource)
            {
                resourceFullAPI.Add(new ResourceFullAPI
                {
                    IdResource = item.IdResource,
                    Name = item.Name,
                    ReleaseDate = item.ReleaseDate,
                    Price = item.Price,
                    NameAuthor = db.Authors.Find(item.IdAuthor).NameAuthor,
                    NamePublishingHouse = db.TypeResources.Find(item.IdTypeResource).NameTypeResource,
                    NameTypeResource = db.PublishingHouses.Find(item.IdPublishingHouse).NamePublishingHouse
                });
            }
            return resourceFullAPI.OrderBy(x => x.Name);
        }

        // GET: api/Resources/5

        public IEnumerable<ResourceFullAPI> GetResource(string word)
        {
            List<ResourceFullAPI> resourceFullAPI = new List<ResourceFullAPI>();
            List<Resource> resource = db.Resources.Include("PublishingHouse").Include("TypeResource").Where(x => x.Name.Contains(word) || x.PublishingHouse.NamePublishingHouse.Contains(word) || x.TypeResource.NameTypeResource.Contains(word)).ToList();
            foreach (var item in resource)
            {
                resourceFullAPI.Add(new ResourceFullAPI
                {
                    IdResource = item.IdResource,
                    Name = item.Name,
                    ReleaseDate = item.ReleaseDate,
                    Price = item.Price,
                    NameAuthor = db.Authors.Find(item.IdAuthor).NameAuthor,
                    NamePublishingHouse = db.TypeResources.Find(item.IdTypeResource).NameTypeResource,
                    NameTypeResource = db.PublishingHouses.Find(item.IdPublishingHouse).NamePublishingHouse
                });
            }

            return resourceFullAPI.OrderBy(x => x.Name);
        }
    }
}