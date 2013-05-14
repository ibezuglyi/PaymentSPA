using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentSPA.Models
{
    public class Payment : BaseEntity
    {
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<Category> Categories { get; set; }

        public UserProfile User { get; set; }
        public int UserId { get; set; }

        public Payment()
        {
            Categories = new List<Category>();
        }
    }
}