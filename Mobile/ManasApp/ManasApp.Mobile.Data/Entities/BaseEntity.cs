using SQLite;
using System;

namespace ManasApp.Mobile.Data.Entities
{
    abstract public class BaseEntity
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
    }
}
