﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.DTO
{
    public class UpdateUserDTO
    {
        public string EId { get; set; }
        public string ChiName { get; set; }
        public string EngName { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public int Status { get; set; }
        public string EmployeeNo { get; set; }
        public DateTime BornDate { get; set; }
    }
}
