using System.Collections.Generic;

namespace ManasApp.Data.Contract.Entities
{
    public class Map : BaseEntity
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public ICollection<Locality> Locality { get; set; }
    }
}
