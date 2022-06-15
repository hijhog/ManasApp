using System.Linq;
using Xamarin.Forms;

namespace ManasApp.Mobile.Common.Extensions
{
    public static class StackNavigationExtension
    {
        public static void ClearStackNavigation(this Shell self)
        {
            var existingPages = self.Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if(page != null)
                    self.Navigation.RemovePage(page);
            }
        }
    }
}
