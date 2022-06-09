using System;
using System.Collections.Generic;

namespace ManasApp.Data.Contract.Entities
{
    public class Locality : BaseEntity
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string Description { get; set; }

        public Guid MapId { get; set; }
        public Map Map { get; set; }

        public ICollection<StorageData> StorageData { get; set; }
    }
}
