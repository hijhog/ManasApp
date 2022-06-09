using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace ManasApp.Mobile.Data.Entities
{
    [Table("Map")]
    public class Map : BaseEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [OneToMany]
        public List<Locality> Localities { get; set; }
    }
}
