using ManasApp.Common.Enums;
using System;

namespace ManasApp.Services.Contract.Models.StorageData
{
    public class StorageDataDto : BaseDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public StorageTypes StorageType { get; set; }
        public Guid LocalityId { get; set; }
    }
}
