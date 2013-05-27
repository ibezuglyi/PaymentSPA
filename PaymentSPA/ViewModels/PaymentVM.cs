using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSPA.ViewModels
{
    public class PaymentVM
    {
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public CategoryVM Category { get; set; }

    }
}