using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Service.Entities
{
    public class SysDict:BaseEntity
    {
        public string Code { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Sort { get; set; }
    }
}
