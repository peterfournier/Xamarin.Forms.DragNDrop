using Xamarin.Forms.DragNDrop;
using System;
namespace MySquad.Models
{
    public class FireTeam : OrderableCollection<Marine>
    {
        public string Name { get; private set; }
        public Marine FireTeamLeader { get; private set; }
        public FireTeam(
            string name,
            Marine fireTeamLeader
            )
        {
            if (fireTeamLeader == null)
                throw new ArgumentNullException(nameof(fireTeamLeader));

            FireTeamLeader = fireTeamLeader;
            Name = name;
        }
        //protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == NotifyCollectionChangedAction.Add)
        //    {
        //        // Fireteams cannot be larger than 4 :)
        //        //if (Count >= 4)
        //        //{
        //        //    foreach (var item in e.NewItems)
        //        //    {
        //        //        if (item is Marine marine)
        //        //            this.Remove(marine);
        //        //    }
        //        //}
        //    }


        //    base.OnCollectionChanged(e);
        //}
    }
}
