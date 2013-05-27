using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentSPA.Models
{
    public class Payment : BaseEntity
    {
        [Required]
        public double Value { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public UserProfile User { get; set; }
        public int UserId { get; set; }
    }
}