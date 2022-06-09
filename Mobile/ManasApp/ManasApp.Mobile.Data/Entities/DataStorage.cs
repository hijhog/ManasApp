using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManasApp.Mobile.Data.Entities
{
    [Table("DataStorage")]
    public class DataStorage : BaseEntity
    {
        public string Url { get; set; }

        [ManyToMany(typeof(LocalityDataStorage))]
        public List<Locality> Localities { get; set; }
    }
}
