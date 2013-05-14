using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PaymentSPA.Models
{
    public class PaymentConfiguration : EntityTypeConfiguration<Payment>
    {
        public PaymentConfiguration()
        {
            HasMany(t => t.Categories).WithMany(t => t.Payments);
            HasRequired(t => t.User);
        }
    }
}