using AutoMapper;
using PaymentSPA.Models;
using PaymentSPA.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSPA.Services
{
    public class PaymentService : IPaymentService
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public PaymentService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }



        public IList<ViewModels.PaymentVM> GetAllPayments()
        {
            return UnitOfWork.PaymentRepository.GetAll().Select(r => Mapper.Map<ViewModels.PaymentVM>(r)).ToList();
        }

        public IList<ViewModels.PaymentVM> GetRecentPayments()
        {
            return null;
        }

        public IList<ViewModels.PaymentVM> GetCurrentMonthPayments()
        {
            var thisMonthStart = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            var thisMonthEnd = thisMonthStart.AddDays(DateTime.DaysInMonth(thisMonthStart.Year, thisMonthStart.Month) - 1);
            return UnitOfWork.PaymentRepository.GetAll(r => r.CreatedAt >= thisMonthStart && r.CreatedAt <= thisMonthEnd).Select(r => Mapper.Map<ViewModels.PaymentVM>(r)).ToList();
        }


        public void Save(ViewModels.PaymentVM paymentVm)
        {
            var payment = new Payment();
            payment.Value = paymentVm.Value;
            payment.UserId = 1;
            payment.CreatedAt = paymentVm.CreatedAt;
            UnitOfWork.PaymentRepository.Add(payment);
            UnitOfWork.Commit();
        }
    }
}