using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Service.Entities
{
    public class UserRoleRelation:BaseEntity
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
