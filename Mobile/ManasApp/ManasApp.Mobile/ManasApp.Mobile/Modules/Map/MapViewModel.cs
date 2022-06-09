using ManasApp.Mobile.Common.Controllers;
using ManasApp.Mobile.Common.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Xamarin.Forms;

namespace ManasApp.Mobile.Modules.Map
{
    public class MapViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly IMapController _mapController;
        public CustomMap Map { get; set; }
        public MapViewModel(IMapController mapController)
        {
            _mapController = mapController;
        }

        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            var id = Guid.Parse(HttpUtility.UrlDecode(query["id"]));
            if (id != Guid.Empty)
            {
                var map = await _mapController.GetAsync(id);
                Map?.MoveToRegion(map.Latitude, map.Longitude);
            }
        }
    }
}
