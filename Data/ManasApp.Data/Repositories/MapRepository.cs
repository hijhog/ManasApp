using ManasApp.Data.Contract.Entities;
using ManasApp.Data.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManasApp.Data.Repositories
{
    public class MapRepository : BaseRepository<Map>, IMapRepository
    {
        public MapRepository(AppDbContext context)
            :base(context)
        {

        }
    }
}
