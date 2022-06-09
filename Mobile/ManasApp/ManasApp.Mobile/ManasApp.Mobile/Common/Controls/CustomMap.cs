using Xamarin.Forms.Maps;

namespace ManasApp.Mobile.Common.Controls
{
    public class CustomMap : Map
    {
        private readonly Distance _distance = new Distance(3400);
        public CustomMap()
        {
            var position = new Position(42.882004, 74.582748);
            MoveToRegion(MapSpan.FromCenterAndRadius(position, _distance));
        }

        public void MoveToRegion(double lat, double longt)
        {
            var position = new Position(lat, longt);
            MoveToRegion(MapSpan.FromCenterAndRadius(position, _distance));
        }
    }
}
