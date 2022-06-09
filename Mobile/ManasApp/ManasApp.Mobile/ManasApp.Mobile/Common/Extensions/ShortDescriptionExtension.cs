using System.Linq;

namespace ManasApp.Mobile.Common.Extensions
{
    public static class ShortDescriptionExtension
    {
        public static string GetShortText(this string self)
        {
            var words = self.Split(' ');
            return string.Join(" ", words.Take(15));
        }
    }
}
