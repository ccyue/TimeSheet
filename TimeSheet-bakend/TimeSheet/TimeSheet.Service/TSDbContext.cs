using Microsoft.EntityFrameworkCore;
using System;
using TimeSheet.Service.Entities;
using TimeSheet.Service.ModleConfig;

namespace TimeSheet.Service
{
    public class TSDbContext : DbContext
    {
        public TSDbContext()
        {

        }
        public TSDbContext(DbContextOptions<TSDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=127.0.0.1;database=timesheet;uid=root;pwd=P@ssw0rd;charset='utf8';SslMode=None;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new SysDictConfig());
            modelBuilder.ApplyConfiguration(new SysDictTypeConfig());
            modelBuilder.ApplyConfiguration(new SysSettingConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserRoleRelationConfig());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleRelation> UserRoleRelation { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Project> SysDicts { get; set; }
        public DbSet<SysSetting> SysDictTypes { get; set; }
        public DbSet<SysSetting> Settings { get; set; }
    }
}
