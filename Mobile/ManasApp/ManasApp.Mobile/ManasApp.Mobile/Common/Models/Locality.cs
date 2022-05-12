using System;

namespace ManasApp.Mobile.Common.Models
{
    public class Locality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? MapId { get; set; }
    }
}
