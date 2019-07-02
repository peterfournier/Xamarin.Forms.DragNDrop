using MySquad.Models;
using MySquad.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySquad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMarinePage : ContentPage
    {
        public Marine Marine { get; set; }
        private List<MarineCorpsRank> _marineCorpsRank;

        public List<MarineCorpsRank> MarineCorpsRanks
        {
            get { return _marineCorpsRank; }
            set { _marineCorpsRank = value; OnPropertyChanged(); }
        }


        public NewMarinePage()
        {
            InitializeComponent();

            Marine = new Marine
            {
                FirstName = "Enter firstname here",
                LastName = "Enter lastname here"
            };
            MarineCorpsRanks = MarineCorpsRankFactory.All();
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddMarine", Marine);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}