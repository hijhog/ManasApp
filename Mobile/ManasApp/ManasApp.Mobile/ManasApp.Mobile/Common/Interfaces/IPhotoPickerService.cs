using System.IO;
using System.Threading.Tasks;

namespace ManasApp.Mobile.Common.Interfaces
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
