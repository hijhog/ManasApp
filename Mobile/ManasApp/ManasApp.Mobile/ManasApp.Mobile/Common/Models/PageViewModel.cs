using System;
using System.Collections.Generic;
using System.Text;

namespace ManasApp.Mobile.Common.Models
{
    public class PageViewModel<TEntity>
        where TEntity : class
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public TEntity[] Data { get; set; }
    }
}
