using ManasApp.Mobile.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace ManasApp.Mobile.Modules.Localities.LocalityDetails
{
    public class LocalityDetailsViewModel : BaseViewModel,IQueryAttributable 
    {
        private readonly ILocalityController _localityController;
        public Command GotoMapCommand { get; set; }
        public ObservableCollection<string> BookInfo { get; set; }
        public LocalityDetailsViewModel(ILocalityController localityController)
        {
            _localityController = localityController;
            GotoMapCommand = new Command(async () => await GotoMap());
            BookInfo = new ObservableCollection<string>();
            Initialize();
        }

        private void Initialize()
        {
            for(int i = 0; i < 20; i++)
            {
                BookInfo.Add($"Item super puper {new Random().Next(10000)}");
            }
        }

        private Guid _id;

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

        private Guid? _mapId;
        public Guid? MapId
        {
            get => _mapId;
            set
            {
                _mapId = value;
                SetProperty(ref _mapId, value);
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
                MapId = locality.MapId;
            }
        }
    }
}
