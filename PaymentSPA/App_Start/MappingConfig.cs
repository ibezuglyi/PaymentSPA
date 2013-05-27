using AutoMapper;
using PaymentSPA.Models;
using PaymentSPA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSPA
{
    public static class MappingConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<Payment, PaymentVM>();
            Mapper.CreateMap<Category, CategoryVM>();
                

        }
    }
}