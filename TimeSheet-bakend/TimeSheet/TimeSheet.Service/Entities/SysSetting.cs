using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Service.Entities
{
    public class SysSetting : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
