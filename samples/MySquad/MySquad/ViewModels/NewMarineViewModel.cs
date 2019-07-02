using MySquad.Models;
using MySquad.Services;
using System.Collections.Generic;

namespace MySquad.ViewModels
{
    public class NewMarineViewModel  : BaseViewModel
    {
        private Marine _marine;

        public Marine Marine
        {
            get { return _marine; }
            set { SetProperty(ref _marine, value); }
        }
        public List<MarineCorpsRank> Ranks { get; set; }

        public NewMarineViewModel()
        {
            this.Marine = new Marine();
            Ranks = MarineCorpsRankFactory.All();
        }
    }
}
