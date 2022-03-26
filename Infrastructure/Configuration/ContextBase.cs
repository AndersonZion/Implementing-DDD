using Entities.Entities;
using Infrastructure.Map;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
   public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }
        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            modelBuilder.ApplyConfiguration(new PessoaConfig());


            //modelBuilder.Entity<Produto>()
            //    .Property(p => p.Valor)
            //    .HasColumnType("decimal(18,4)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
