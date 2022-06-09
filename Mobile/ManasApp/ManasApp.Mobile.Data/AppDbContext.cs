using ManasApp.Mobile.Data.Entities;
using ManasApp.Mobile.Data.Repositories;
using SQLite;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Data
{
    public class AppDbContext
    {
        private readonly SQLiteAsyncConnection _database;
        private LocalityRepository _localityRepository;
        private MapRepository _mapRepository;
        public AppDbContext(SQLiteAsyncConnection database)
        {
            _database = database;

            CreateTables();
        }

        private void CreateTables()
        {
            Task.WaitAll(
                _database.CreateTableAsync<Locality>(),
                _database.CreateTableAsync<Map>(),
                _database.CreateTableAsync<DataStorage>(),
                _database.CreateTableAsync<LocalityDataStorage>()
            );
        }

        public LocalityRepository LocalityRepository { get => _localityRepository ?? new LocalityRepository(_database); }
        public MapRepository MapRepository { get => _mapRepository ?? new MapRepository(_database); }
    }
}
