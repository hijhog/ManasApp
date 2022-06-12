using ManasApp.Services.Contract.Models.StorageData;
using System;
using System.Collections.Generic;

namespace ManasApp.Services.Contract.Models.Locality
{
    public class LocalityDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? MapId { get; set; }
        public IEnumerable<StorageDataDto> StorageData { get; set; }
    }
}
