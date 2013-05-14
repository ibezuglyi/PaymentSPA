﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentSPA.Models
{
    public class Category : BaseEntity
    {
        public int Name { get; set; }
        public IList<Payment> Payments { get; set; }

        public Category()
        {
            Payments = new List<Payment>();
        }
    }
}