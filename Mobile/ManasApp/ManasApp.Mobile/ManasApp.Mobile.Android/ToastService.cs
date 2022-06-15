using Android.App;
using Android.Widget;
using ManasApp.Mobile.Common.Interfaces;
using ManasApp.Mobile.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ToastService))]
namespace ManasApp.Mobile.Droid
{
    public class ToastService : IToastService
    {
        public void Show(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}