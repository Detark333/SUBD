using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SUBD.Model
{
    public class Information
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Passport { get; set; }
        [ForeignKey("InformationId")]
        public virtual List<Client> Clients { get; set; }
        [ForeignKey("InformationId")]
        public virtual List<SalePeople> SalePeoples { get; set; }
    }
}
