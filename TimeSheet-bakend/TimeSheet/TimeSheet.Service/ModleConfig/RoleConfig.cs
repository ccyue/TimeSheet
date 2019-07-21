using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Service.Entities;

namespace TimeSheet.Service.ModleConfig
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Property(p => p.IsDeleted).HasColumnType("bit(1)");
        }
    }
}
