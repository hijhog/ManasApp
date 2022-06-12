using System;
using System.Collections.Generic;
using System.Text;

namespace ManasApp.Mobile.Common.Models
{
    public class OperationResult<TResult>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public TResult Result { get; set; }
    }
}
