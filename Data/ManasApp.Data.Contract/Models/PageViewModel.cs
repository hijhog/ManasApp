using System.Collections.Generic;

namespace ManasApp.Data.Contract.Models
{
    public class PageViewModel<TEntity>
        where TEntity : class
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<TEntity> Data { get; set; }

        public PageViewModel()
        {
            PageSize = 10;
            Data = new List<TEntity>();
        }
    }
}
