using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetAssignment.DataEntities
{
    public class BaseEntity
    {
        [JsonIgnore]
        [NotMapped]
        public int Id { get; set; }
    }
}
