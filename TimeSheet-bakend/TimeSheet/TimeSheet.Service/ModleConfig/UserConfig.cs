using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TimeSheet.Service.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimeSheet.Service.ModleConfig
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.Property(p => p.EId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ChiName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.EngName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Gender).HasColumnType("bit(1)");
            builder.Property(p => p.EmployeeNo).HasMaxLength(20);
            builder.Property(p => p.PassWordHash).IsRequired().HasMaxLength(200);
            builder.Property(p => p.PassWordSalt).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Property(p => p.PhoneNum).IsRequired().HasMaxLength(20).IsUnicode(false);
            builder.Property(p => p.IsDeleted).HasColumnType("bit(1)");
        }
    }
}
