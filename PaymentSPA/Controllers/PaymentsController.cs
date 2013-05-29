using PaymentSPA.Models;
using PaymentSPA.Services;
using PaymentSPA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PaymentSPA.Controllers
{
    public class PaymentsController : ApiController
    {
        public IPaymentService PaymentService { get; set; }
        public PaymentsController(IPaymentService paymentService)
        {
            if (paymentService == null) throw new ArgumentException("paymentService");

            PaymentService = paymentService;
        }
        [ActionName("getall")]
        public IEnumerable<PaymentListVM> GetMonthView()
        {
            return PaymentListVM.BuildGrouppedList(PaymentService.GetCurrentMonthPayments());
        }

        [HttpPost]
        public HttpResponseMessage Put(PaymentVM paymentVm)
        {
            if (ModelState.IsValid)
            {
                PaymentService.Save(paymentVm);
            }
            return Request.CreateResponse(HttpStatusCode.OK, GetMonthView());
        }

    }
}
