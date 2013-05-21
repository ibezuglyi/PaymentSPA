using PaymentSPA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSPA.Services
{
    public interface IPaymentService
    {
        IList<PaymentVM> GetAllPayments();
        IList<PaymentVM> GetRecentPayments();
        IList<PaymentVM> GetCurrentMonthPayments();
        void Save(PaymentVM paymentVm);
    }
}
