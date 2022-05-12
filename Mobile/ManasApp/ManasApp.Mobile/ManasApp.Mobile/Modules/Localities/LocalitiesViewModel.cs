using ManasApp.Mobile.Common.Controllers;
using ManasApp.Mobile.Common.Models;
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

        public Command RemainingItemsThresholdReachedCommand { get; set; }


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

        public LocalitiesViewModel(ILocalityController localityController)
        {
            _localityController = localityController;
            Localities = new ObservableCollection<Locality>();

            var description = string.Join(" ", Enumerable.Repeat("Template description", 4));
            var length = Localities.Count;
            for (int i = 0; i < 20; i++)
            {
                _localities.Add(new Locality
                {
                    Id = Guid.NewGuid(),
                    Name = $"Locality #{length + i}",
                    Description = description,
                    MapId = (new Random().Next(0, 1) == 0) ? Guid.NewGuid() : (Guid?)null
                });
            }

            RemainingItemsThresholdReachedCommand = new Command(async () => await GetItemsAsync(15));
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

        public async Task GetItemsAsync(int count)
        {
            if (_isBusy) 
                return;

            IsBusy = true;
            IsLoading = true;
            var list = new List<Locality>();
            var description = string.Join(" ", Enumerable.Repeat("Template description", 20));
            var length = Localities.Count;
            await Task.Delay(3000);
            IsLoading = false;
            for (int i = 0; i < count; i++)
            {
                _localities.Add(new Locality
                {
                    Id = Guid.NewGuid(),
                    Name = $"Locality #{length + i}",
                    Description = description,
                    MapId = (new Random().Next(0, 1) == 0) ? Guid.NewGuid() : (Guid?)null
                });

            }

            IsBusy = false;

            //OnPropertyChanged(nameof(Localities));


        }
    }
}
