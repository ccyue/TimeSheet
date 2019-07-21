using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string EId { get; set; }
        public string ChiName { get; set; }
        public string EngName { get; set; }
        public bool Gender { get; set; }
        public DateTime BornDate { get; set; }
        public string EmployeeNo { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public int Status { get; set; }
        public int LoginErrorTimes { get; set; }
        public DateTime? LastFailedAttemptDateTime { get; set; }
        public DateTime? LastLogOnDateTime { get; set; }
        public DateTime? LastPasswordUpdateDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
