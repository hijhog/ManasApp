using SQLiteNetExtensions.Attributes;
using System;

namespace ManasApp.Mobile.Data.Entities
{
    public class LocalityDataStorage
    {
        [ForeignKey(typeof(Locality))]
        public Guid LocalityId { get; set; }
        [ForeignKey(typeof(DataStorage))]
        public Guid DataStorageId { get; set; }
    }
}
