using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Service.Entities
{
    public class User:BaseEntity
    {
        public string EId { get; set; }
        public string ChiName { get; set; }
        public string EngName { get; set; }
        public string PassWordSalt { get; set; }
        public string PassWordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public int LoginErrorTimes { get; set; } = 0;
        public DateTime? LastFailedAttemptDateTime { get; set; }
        public DateTime? LastLogOnDateTime { get; set; }
        public DateTime? LastPasswordUpdateDateTime { get; set; }
    }
}
