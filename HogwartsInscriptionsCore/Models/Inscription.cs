using System;
using System.Collections.Generic;

#nullable disable

namespace HogwartsInscriptionsCore.Models
{
    public partial class Inscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentNum { get; set; }
        public byte Age { get; set; }
        public string House { get; set; }
        public string State { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
