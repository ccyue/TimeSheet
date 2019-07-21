using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Service.Entities;

namespace TimeSheet.Service.ModleConfig
{
    public class UserRoleRelationConfig : IEntityTypeConfiguration<UserRoleRelation>
    {
        public void Configure(EntityTypeBuilder<UserRoleRelation> builder)
        {
            builder.ToTable("user-role-relation");
            builder.HasOne(p => p.Role).WithMany().HasForeignKey(p => p.RoleId).IsRequired();
            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId).IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnType("bit(1)");
        }
    }
}
