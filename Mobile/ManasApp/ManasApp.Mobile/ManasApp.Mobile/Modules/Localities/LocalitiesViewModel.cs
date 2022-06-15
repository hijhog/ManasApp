using ManasApp.Mobile.Common.Controllers;
using ManasApp.Mobile.Common.Models;
using ManasApp.Mobile.Common.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ManasApp.Mobile.Modules.Localities
{
    public class LocalitiesViewModel : BaseViewModel
    {
        private readonly ILocalityController _localityController;
        private int page = 1;
        private string searchText = string.Empty;

        public Command RemainingItemsThresholdReachedCommand { get; set; }
        public Command TappedCommand { get; set; }


        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set { SetProperty(ref _isBusy, value); }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { SetProperty(ref _isLoading, value); }
        }

        public LocalitiesViewModel(
            ILocalityController localityController,
            AuthService authService)
            :base(authService)
        {
            _localityController = localityController;
            Localities = new ObservableCollection<Locality>();            

            RemainingItemsThresholdReachedCommand = new Command(async () => await GetItemsAsync());
            TappedCommand = new Command<Locality>(OpenDetails);
        }

        public async Task InitialLocalities()
        {
            if (!string.IsNullOrEmpty(searchText))
                return;

            var collection = await _localityController.GetScrollLocalitiesAsync(string.Empty, GetNextPage()).ConfigureAwait(false);

            foreach (var locality in collection)
            {
                _localities.Add(locality);
            }
        }

        private ObservableCollection<Locality> _localities;
        public ObservableCollection<Locality> Localities
        {
            get => _localities;
            set { SetProperty(ref _localities, value); }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set { SetProperty(ref _description, value); }
        }

        private Guid? _mapId;
        public Guid? MapId
        {
            get => _mapId;
            set { SetProperty(ref _mapId, value); }
        }

        public async Task GetItemsAsync()
        {
            if (_isBusy) 
                return;

            IsBusy = true;
            IsLoading = true;

            if (!string.IsNullOrEmpty(searchText) && Localities.Count < 15)
            {
                IsLoading = false;
                IsBusy = false;
                return;
            }

            var list = await _localityController.GetScrollLocalitiesAsync(searchText, GetNextPage()).ConfigureAwait(false);
            IsLoading = false;

            foreach (var locality in list)
            {
                if(Localities.FirstOrDefault(x=>x.Name == locality.Name) == null)
                {
                    Localities.Add(locality);
                }
            }
            
            IsBusy = false;
        }

        private async void OpenDetails(Locality model)
        {
            if (model == null)
                return;

            await Shell.Current.GoToAsync($"/localitydetails?id={model.Id}");
        }

        public async Task SearchLocalities(string searchText)
        {
            this.searchText = searchText;
            if (_isBusy)
                return;

            IsBusy = true;
            IsLoading = true;
            Localities.Clear();
            var list = await _localityController.GetScrollLocalitiesAsync(searchText, GetNextPage()).ConfigureAwait(false);
            IsLoading = false;

            foreach (var locality in list)
            {
                Localities.Add(locality);
            }

            IsBusy = false;
        }

        private int GetNextPage()
        {
            int pageSize = 15;
            int pages = Localities.Count / pageSize;
            return pages + 1;
        }
    }
}
