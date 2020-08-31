using System;
using System.Collections.Generic;

namespace dotNetAssignment.DataEntities
{
    public partial class Country
    {
        public Country()
        {
            Contracts = new HashSet<Contracts>();
            CoveragePlan = new HashSet<CoveragePlan>();
        }

        public int Id { get; set; }
        public string Country1 { get; set; }
        public int? CountryCode { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
        public virtual ICollection<CoveragePlan> CoveragePlan { get; set; }
    }
}
