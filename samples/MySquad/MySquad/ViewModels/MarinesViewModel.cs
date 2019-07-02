using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using MySquad.Models;
using Xamarin.Forms.DragNDrop;
using MySquad.Views;

namespace MySquad.ViewModels
{
    public class MarinesViewModel : BaseViewModel
    {
        public OrderableCollection<Marine> Marines { get; set; }
        public Command LoadMarinesCommand { get; set; }

        public MarinesViewModel()
        {
            Title = "Browse";
            Marines = new OrderableCollection<Marine>();
            LoadMarinesCommand = new Command(async () => await ExecuteLoadMarinesCommand());

            Marines.OrderChanged += MarinesCollectionChanged;
            Marines.CollectionChanged += MarinesCollectionChanged;

            MessagingCenter.Subscribe<NewMarinePage, Marine>(this, "AddMarine", async (obj, marine) =>
            {
                var newMarine = marine as Marine;
                Marines.Add(newMarine);
                await DataStore.AddMarineAsync(newMarine);
            });
        }

        async Task ExecuteLoadMarinesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Marines.Clear();
                var marines = await DataStore.GetMarinesAsync(true);
                //var counter = 1;
                foreach (var marine in marines)
                {
                    //marine.Order = counter;
                    Marines.Add(marine);
                    //counter++;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        void MarinesCollectionChanged (object sender, EventArgs eventArgs)
        {
            var counter = 1;
            foreach (var marine in Marines)
            {
                marine.Order = counter;
                counter++;
            }
        }
    }
}