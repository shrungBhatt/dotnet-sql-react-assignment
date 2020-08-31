using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetAssignment.Models
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public int Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
