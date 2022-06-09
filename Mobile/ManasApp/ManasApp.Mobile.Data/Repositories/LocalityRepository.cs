using ManasApp.Mobile.Data.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Data.Repositories
{
    public class LocalityRepository : BaseRepository<Locality>
    {
        public LocalityRepository(SQLiteAsyncConnection database)
            : base(database) { }
    }
}
