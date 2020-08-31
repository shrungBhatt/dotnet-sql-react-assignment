using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace dotNetAssignment.DataEntities
{
    public partial class Contracts : BaseEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int Gender { get; set; }
        public int Country { get; set; }
        public int CoveragePlan { get; set; }
        public DateTime Dob { get; set; }
        public DateTime SaleDate { get; set; }
        public int? RateChart { get; set; }

        [JsonIgnore]
        public virtual Country CountryNavigation { get; set; }
        [JsonIgnore]
        public virtual CoveragePlan CoveragePlanNavigation { get; set; }
        [JsonIgnore]
        public virtual Gender GenderNavigation { get; set; }
        [JsonIgnore]
        public virtual RateChart RateChartNavigation { get; set; }
    }
}
