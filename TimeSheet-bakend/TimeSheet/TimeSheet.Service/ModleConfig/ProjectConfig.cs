using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Service.Entities;

namespace TimeSheet.Service.ModleConfig
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("project");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.Remark).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.Owner).IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnType("bit(1)");
        }
    }
}
