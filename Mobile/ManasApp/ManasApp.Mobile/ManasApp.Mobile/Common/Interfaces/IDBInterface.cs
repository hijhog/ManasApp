using SQLite;

namespace ManasApp.Mobile.Common.Interfaces
{
    public interface IDBInterface
    {
        SQLiteAsyncConnection CreateConnection();
    }
}
