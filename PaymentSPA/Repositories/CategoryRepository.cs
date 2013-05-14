using PaymentSPA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaymentSPA.Repositories
{
    public class CategoryRepository:EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context):base(context)
        {

        }
    }
}