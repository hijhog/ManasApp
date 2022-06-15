using System;
using System.Collections.Generic;
using System.Text;

namespace ManasApp.Services.Contract.Models.Locality
{
    public class LocalityDetails : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? MapId { get; set; }
        public IEnumerable<StorageDataItem> StorageData { get; set; }
    }

    public class StorageDataItem
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
    }
}
