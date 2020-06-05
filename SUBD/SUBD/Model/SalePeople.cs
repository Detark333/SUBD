using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SUBD.Model
{
    public class SalePeople
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WageDollars { get; set; }
        [Required]
        public int InformationId { get; set; }
        [ForeignKey("SalePeopleId")]
        public virtual List<Contract> Contracts { get; set; }
    }
}
