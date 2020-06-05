using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SUBD.Model
{
    public class Contract
    {
        public int Id { get; set; }
        public string Curency { get; set; }
        public int Amount { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int SalePeopleId { get; set; }
        [Required]
        public int AutoId { get; set; }
    }
}
