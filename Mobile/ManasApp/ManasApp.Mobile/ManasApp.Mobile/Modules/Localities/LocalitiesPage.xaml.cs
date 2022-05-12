using Autofac;
using ManasApp.Mobile.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManasApp.Mobile.Modules.Localities
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalitiesPage : ContentPage
    {
        private readonly Random random = new Random();
        private readonly LocalitiesViewModel viewModel;
        
        public LocalitiesPage()
        {
            InitializeComponent();
            viewModel = App.Container.Resolve<LocalitiesViewModel>();
            BindingContext = viewModel;
            //foreach(var s in GetItems(50))
            //{
            //    myItems.Add(s);
            //}
            //myCollection.RemainingItemsThreshold = 5;
            //myCollection.RemainingItemsThresholdReached += MyCollection_RemainingItemsThresholdReached;
        }

        //private void MyCollection_RemainingItemsThresholdReached(object sender, EventArgs e)
        //{
        //    //await viewModel.GetItemsAsync(15);
        //}

        //private List<Locality> GetItems(int numberOfItems)
        //{
        //    var resultList = new List<Locality>();
        //    var count = myItems.Count;
        //    var description = string.Join(" ",Enumerable.Repeat("Template description", 20));

        //    for(var i = 0; i <= numberOfItems; i++)
        //    {
        //        resultList.Add(new Locality
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = $"Locality #{count + i}",
        //            Description = description,
        //            MapId = (new Random().Next(0,1) == 0) ? Guid.NewGuid() : (Guid?)null
        //        });
        //    }

        //    return resultList;
        //}
    }
}