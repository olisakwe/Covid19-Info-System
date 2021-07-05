using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19_Info_System.Models
{
    class Covid19CaseModel
    {
        public decimal Confirmed { get; set; }
        public decimal Active { get; set; }
        public decimal Discharge { get; set; }
        public decimal Death { get; set; }
    }
}
