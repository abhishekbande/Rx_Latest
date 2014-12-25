using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordGlobal.Rx.Models
{
    public class PatientDetails
    {
        
            # region PatientProfile
            public long PatientId { get; set; }
            public long LoggerId { get; set; }
            public string PatientName { get; set; }
            public string EmailId { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
            public long PhoneNo { get; set; }
            public string MarirtalStatus { get; set; }
            public int Temperature { get; set; }
            public string Gender { get; set; }
            public int Weight { get; set; }
            public DateTime AdmitDateTime { get; set; }
            public string Bp { get; set; }

            # endregion
        
    }

}