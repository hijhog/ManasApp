using ManasApp.Common.Enums;
using System;

namespace ManasApp.Data.Contract.Entities
{
    public class StorageData : BaseEntity
    {
        public string Name { get; set; }
        public StorageTypes StorageType { get; set; }
        public string UrlAddress { get; set; }

        public Guid LocalityId { get; set; }
        public Locality Locality { get; set; }
    }
}
