using System;
using System.Collections.Generic;

namespace dotNetAssignment.DataEntities
{
    public partial class Gender
    {
        public Gender()
        {
            Contracts = new HashSet<Contracts>();
            RateChart = new HashSet<RateChart>();
        }

        public int Id { get; set; }
        public string Gender1 { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
        public virtual ICollection<RateChart> RateChart { get; set; }
    }
}
