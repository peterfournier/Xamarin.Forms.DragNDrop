using MySquad.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySquad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SquadPage : ContentPage
    {
        SquadViewModel viewModel;

        public SquadPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SquadViewModel();
        }

        //async void AddItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Squad?.Count == 0)
                viewModel.LoadSquadCommand.Execute(null);
        }
    }
}