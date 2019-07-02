using MySquad.Models;
using MySquad.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.DragNDrop;

namespace MySquad.ViewModels
{
    public class SquadViewModel : BaseViewModel
    {
        private Squad _squad;

        public Squad Squad
    {
            get { return _squad; }
            set { SetProperty(ref _squad, value); }
        }

        public Command LoadSquadCommand { get; set; }

        public SquadViewModel()
        {
            Title = "Browse";
            LoadSquadCommand = new Command(async () => await ExecuteLoadSquadCommand());
            Squad = new Squad("First Squad", new Marine { FirstName = "Theo", LastName = "Robrecht", Rank = MarineCorpsRankFactory.Sergeant });
            Squad.OrderChanged += (sender, eventArgs) =>
            {
                if (eventArgs is GroupedOrderableCollectionChangedEventArgs groupEventArgs)
                {
                    int order = 1;
                    foreach (var item in groupEventArgs.OldGroup)
                    {
                        if (item is Marine marine)
                        {
                            marine.Order = order;
                        }
                        order++;
                    }

                    order = 1;
                    foreach (var item in groupEventArgs.NewGroup)
                    {
                        if (item is Marine marine)
                        {
                            //if (marine.Id == )
                            marine.Order = order;
                        }
                        order++;
                    }
                }
            };

            //MessagingCenter.Subscribe<NewMarinePage, Marine>(this, "AddMarine", async (obj, marine) =>
            //{
            //    var newMarine = marine as Marine;
            //    Marines.Add(newMarine);
            //    await DataStore.AddMarineAsync(newMarine);
            //});
        }

        async Task ExecuteLoadSquadCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Squad.Clear();
                var teams = await DataStore.GetFireTeamsAsync(true);
                foreach (var team in teams)
                {
                    Squad.Add(team);
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
    }
}
