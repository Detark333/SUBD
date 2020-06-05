using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SUBD.Model
{
    public class Auto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string TypeMotor { get; set; }
        public int CountAirbags { get; set; }
        [ForeignKey("AutoId")]
        public virtual List<Contract> Contracts { get; set; }
    }
}
