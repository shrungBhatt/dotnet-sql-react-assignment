using System;
using System.Collections.Generic;

namespace dotNetAssignment.DataEntities
{
    public partial class ContractsView : BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public DateTime Dob { get; set; }
        public DateTime SaleDate { get; set; }
        public string CoveragePlan { get; set; }
        public decimal NetPrice { get; set; }
    }
}
