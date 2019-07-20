using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Service.Entities
{
    public class Project: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public int Owner { get; set; }
        public int Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int SystemName { get; set; }
        public int ProjectType { get; set; }
    }
}
