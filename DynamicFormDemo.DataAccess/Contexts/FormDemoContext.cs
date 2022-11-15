using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.Entity.Abstract;
using DynamicFormDemo.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DynamicFormDemo.DataAccess.Contexts
{
    public class FormDemoContext : DbContext
    {
        public FormDemoContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            #region RelationShips

            modelBuilder.Entity<Form>()
                .HasOne(f => f.User)
                .WithMany(u => u.Forms)
                .HasForeignKey(f => f.CreatedBy);

            modelBuilder.Entity<Field>()
                .HasOne(f => f.Form)
                .WithMany(fm => fm.Fields)
                .HasForeignKey(f => f.FormId);

            #endregion

            #region Seed Data

            modelBuilder.Entity<Form>().HasData(new Form
            {
                Id = 1,
                CreatedBy = 1,
                Name = "Login Form",
                CreatedAt = DateTime.UtcNow,
                Description = ""
            });

            modelBuilder.Entity<Field>().HasData(

                new Field
                {
                    Id = 1,
                    FormId = 1,
                    Name = "UserName",
                    DataType = "STRING",
                    Required = true
                }, new Field
                {
                    Id = 2,
                    FormId = 1,
                    Name = "Password",
                    DataType = "STRING",
                    Required = true
                }
            );

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "veyselhim",
                Password = "12345"
            });

            #endregion

        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && e.State is EntityState.Added);

            foreach (var entityEntry in entries)
            {

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);

        }


        public DbSet<Form> Forms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Field> Fields { get; set; }
    }
}
