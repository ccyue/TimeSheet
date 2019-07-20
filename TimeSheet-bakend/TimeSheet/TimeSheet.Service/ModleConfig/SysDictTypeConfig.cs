using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Service.Entities;

namespace TimeSheet.Service.ModleConfig
{
    public class SysDictTypeConfig : IEntityTypeConfiguration<SysDictType>
    {
        public void Configure(EntityTypeBuilder<SysDictType> builder)
        {
            builder.ToTable("sys-dict-type");
            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}
