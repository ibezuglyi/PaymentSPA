using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentSPA.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}