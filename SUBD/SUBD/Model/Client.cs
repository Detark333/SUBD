using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SUBD.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int InformationId { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<Contract> Contracts { get; set; }
    }
}
