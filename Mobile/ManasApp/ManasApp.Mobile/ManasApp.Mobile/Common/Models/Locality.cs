using System;
using System.Collections.Generic;

namespace ManasApp.Mobile.Common.Models
{
    public class Locality
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? MapId { get; set; }
        public List<StorageDataItem> StorageData { get; set; }
    }

    public class StorageDataItem
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
    }
}
