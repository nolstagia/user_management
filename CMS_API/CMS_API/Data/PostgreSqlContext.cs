using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_API.Models;


using Microsoft.AspNetCore.Identity;

namespace CMS_API.Data
{
    public class PostgreSqlContext : DbContext
    {
       
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserHasRole>()
                .HasOne(u => u.user)
                .WithMany(ur => ur.userHasRoles)
                .HasForeignKey(ui => ui.idUser);

            modelBuilder.Entity<UserHasRole>()
                .HasOne(r => r.role)
                .WithMany(ur => ur.userHasRoles)
                .HasForeignKey(ri => ri.idRole);

            modelBuilder.Entity<RoleHasPermission>()
                .HasOne(r => r.role)
                .WithMany(rp => rp.roleHasPermissions)
                .HasForeignKey(ri => ri.idRole);

            modelBuilder.Entity<RoleHasPermission>()
                .HasOne(p => p.permission)
                .WithMany(rp => rp.roleHasPermissions)
                .HasForeignKey(pi => pi.idPermission);
        }

        
        public DbSet<User> users { set; get; }
        public DbSet<Role> role { set; get; }
        public DbSet<Permission> permission { set; get; }
        public DbSet<UserHasRole> userHasRole { get; set; }
        public DbSet<RoleHasPermission> roleHasPermission { get; set; }
       
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
