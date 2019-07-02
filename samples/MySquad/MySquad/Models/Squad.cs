using System;
using Xamarin.Forms.DragNDrop.Models;

namespace MySquad.Models
{
    public class Squad : GroupedOrderableCollection<FireTeam>
    {
        public Marine SquadLeader { get; set; }
        public string Name { get; set; }

        public Squad()
        {

        }
        public Squad(
            string name,
            Marine squadLeader
            )
        {
            if (squadLeader == null)
                throw new ArgumentNullException(nameof(squadLeader));

            SquadLeader = squadLeader;
            Name = name;
        }
    }
}
