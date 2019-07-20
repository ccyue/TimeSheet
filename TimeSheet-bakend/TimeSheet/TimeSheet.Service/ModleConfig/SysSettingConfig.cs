using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Service.Entities;

namespace TimeSheet.Service.ModleConfig
{
    public class SysSettingConfig : IEntityTypeConfiguration<SysSetting>
    {
        public void Configure(EntityTypeBuilder<SysSetting> builder)
        {
            builder.ToTable("sys-setting");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Value).IsRequired().HasMaxLength(1000);
        }
    }
}
