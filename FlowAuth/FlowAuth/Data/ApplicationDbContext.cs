using System;
using System.Collections.Generic;
using System.Text;
using FlowAuth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<TaskDescription> TaskDescrptions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SuppliedBy> SuppliedBys { get; set; }
        public DbSet<Assigned> Assigneds { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<PhaseName> PhaseNames { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaskDescription>().ToTable("Tasks");
            builder.Entity<Staff>().ToTable("Staff");
            builder.Entity<Client>().ToTable("Client");
            builder.Entity<Supplier>().ToTable("Supplier");
            builder.Entity<Project>().ToTable("Project");
            builder.Entity<SuppliedBy>().ToTable("SuppliedBy");
            builder.Entity<Assigned>().ToTable("Assigned");
            builder.Entity<Claim>().ToTable("Claim");
            builder.Entity<Log>().ToTable("Log");
            builder.Entity<Leave>().ToTable("Leave");
            builder.Entity<Phase>().ToTable("Phase");
            builder.Entity<PhaseName>().ToTable("PhaseName");


            //Phases
            builder.Entity<PhaseName>()
                .HasMany(p => p.Phases)
                .WithOne(pn => pn.PhaseName)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
                .HasMany(p => p.Phases)
                .WithOne(pr => pr.Project)
                .OnDelete(DeleteBehavior.Restrict);

            //AppUser and Staff
            builder.Entity<AppUser>()
                .HasOne(s => s.Staff)
                .WithOne(a => a.AppUser)
                .OnDelete(DeleteBehavior.Restrict);

            //Leaves
            builder.Entity<Staff>()
                .HasMany(l => l.Leaves)
                .WithOne(s => s.Staff)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppUser>()
                .HasMany(l => l.Leaves)
                .WithOne(a => a.AppUser)
                .OnDelete(DeleteBehavior.Restrict);

            //Claims
            builder.Entity<Staff>()
                .HasMany(c => c.Claims)
                .WithOne(s => s.Staff)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppUser>()
                .HasMany(c => c.Claims)
                .WithOne(a => a.AppUser)
                .OnDelete(DeleteBehavior.Restrict);

            //Client and Project
            builder.Entity<Client>()
                .HasMany(p => p.Projects)
                .WithOne(c => c.Client)
                .OnDelete(DeleteBehavior.Restrict);

            //Assigneds
            builder.Entity<Staff>()
                .HasMany(a => a.Assigneds)
                .WithOne(s => s.Staff)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
                .HasMany(a => a.Assigneds)
                .WithOne(p => p.Project)
                .OnDelete(DeleteBehavior.Restrict);

            //Supplied By
            builder.Entity<Project>()
                .HasMany(sb => sb.SuppliedBys)
                .WithOne(p => p.Project)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Supplier>()
               .HasMany(sb => sb.SuppliedBys)
               .WithOne(p => p.Supplier)
               .OnDelete(DeleteBehavior.Restrict);

            //Logs
            builder.Entity<TaskDescription>()
                .HasMany(l => l.Logs)
                .WithOne(t => t.TaskDescription)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
                .HasMany(l => l.Logs)
                .WithOne(p => p.Project)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Staff>()
                .HasMany(l => l.Logs)
                .WithOne(s => s.Staff)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<FlowAuth.Models.AppRole> AppRole { get; set; }

    }
}
