using System;
using System.Collections.Generic;
using System.Text;

namespace MySquad.Models
{
    public class Marine : BaseModel
    {
        private int _order;

        // For demo
        public int Order
        {
            get { return _order; }
            set { SetPropertyChanged(ref _order, value); }
        }

        public string FullName => $"{LastName}, {FirstName}";
        public Guid ID { get; set; } = Guid.NewGuid();
        public MarineCorpsRank Rank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
