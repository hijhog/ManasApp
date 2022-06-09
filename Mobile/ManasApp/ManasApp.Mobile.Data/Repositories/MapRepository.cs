using ManasApp.Mobile.Data.Entities;
using SQLite;

namespace ManasApp.Mobile.Data.Repositories
{
    public class MapRepository : BaseRepository<Map>
    {
        public MapRepository(SQLiteAsyncConnection database)
            : base(database)
        { }
    }
}
