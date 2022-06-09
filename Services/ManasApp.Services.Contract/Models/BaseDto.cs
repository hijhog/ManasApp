using System;

namespace ManasApp.Services.Contract.Models
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
