using ManasApp.Mobile.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace ManasApp.Mobile.Modules.Localities.LocalityDetails
{
    public class LocalityDetailsViewModel : BaseViewModel,IQueryAttributable 
    {
        private readonly ILocalityController _localityController;
        public Command GotoMapCommand { get; set; }
        public LocalityDetailsViewModel(ILocalityController localityController)
        {
            _localityController = localityController;
            GotoMapCommand = new Command(async () => await GotoMap());
        }

        private Guid _id;
        private Guid? _mapId;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                SetProperty(ref _name, value);
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                SetProperty(ref _description, value);
            }
        }

        private async Task GotoMap()
        {
            await Shell.Current.GoToAsync($"maps?id={_mapId}");
        }

        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            _id = Guid.Parse(HttpUtility.UrlDecode(query["id"]));

            var locality = await _localityController.GetLocality(_id);

            if(locality != null)
            {
                Name = locality.Name;
                Description = locality.Description;
                _mapId = locality.MapId;
            }
        }
    }
}
