using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace ManasApp.Mobile.Data.Entities
{
    [Table("Locality")]
    public class Locality : BaseEntity
    {
        public string NormalizedName { get; set; }
        public string Description { get; set; }

        [ForeignKey(typeof(Map))]
        public string MapId { get; set; }
        [ManyToMany(typeof(LocalityDataStorage))]
        public List<DataStorage> DataStorages { get; set; }
    }
}
