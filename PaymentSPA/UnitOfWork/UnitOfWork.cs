using PaymentSPA.Models;
using PaymentSPA.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaymentSPA.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private PaymentContext DbContext;

        public IPaymentRepository PaymentRepository { get; set; }

        public UnitOfWork(DbContext context, IPaymentRepository paymentRepository)
        {
            CreateContext(context);
            if (paymentRepository == null) throw new ArgumentException("paymentRepository");

            PaymentRepository = paymentRepository;
        }

        private void CreateContext(DbContext context)
        {
            DbContext = context as PaymentContext;
            if (DbContext == null) throw new ArgumentException("context");

            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }
        
        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
        #endregion


        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}