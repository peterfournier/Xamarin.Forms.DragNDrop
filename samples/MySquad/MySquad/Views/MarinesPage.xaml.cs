using MySquad.Models;
using MySquad.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySquad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarinesPage : ContentPage
    {
        MarinesViewModel viewModel;

        public MarinesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MarinesViewModel();
        }

        async void OnMarineSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Marine;
            if (item == null)
                return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            MarinessListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewMarinePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Marines.Count == 0)
                viewModel.LoadMarinesCommand.Execute(null);
        }
    }
}