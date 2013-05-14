using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PaymentSPA.Models
{
    public class PaymentContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<PaymentContext>(null);

            modelBuilder.Configurations.Add(new PaymentConfiguration());
        }
        public PaymentContext()
            : base("PaymentHistory")
        {
            
        }
    }
}