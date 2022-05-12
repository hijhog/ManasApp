using ManasApp.Mobile.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManasApp.Mobile.Common.Controllers
{
    public class LocalityController : ILocalityController
    {
        public IEnumerable<Locality> GetLocalities()
        {
            var list = new List<Locality>();
            for(int i = 0; i < 20; i++)
            {
                list.Add(new Locality 
                { 
                    Id = Guid.NewGuid(),
                    Name = $"Locality #{i+1}",
                    Description = "Template description",
                    MapId = Guid.NewGuid()
                });
            }

            return list;
        }
    }

    public interface ILocalityController
    {
        IEnumerable<Locality> GetLocalities();
    }
}
