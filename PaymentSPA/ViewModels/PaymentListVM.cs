using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSPA.ViewModels
{
    public class PaymentListVM
    {
        public IList<PaymentVM> Payments { get; set; }
        public string Title { get; set; }
        public double Total { get; set; }

        public PaymentListVM()
        {
            Payments = new List<PaymentVM>();
        }

        public static IEnumerable<PaymentListVM> BuildGrouppedList(IList<PaymentVM> payments)
        {
            var paymentGroups = payments.GroupBy(r => r.CreatedAt.Date, r => r, (key, list) => new PaymentListVM() { Title = key.Date.ToShortDateString(), Payments = list.ToList(), Total = list.Sum(r => r.Value) });
            return paymentGroups;
        }
    }
}