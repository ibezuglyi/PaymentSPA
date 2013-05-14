using PaymentSPA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaymentSPA.Repositories
{
    public class PaymentRepository : EFRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DbContext context):base(context)
        {

        }
    }
}