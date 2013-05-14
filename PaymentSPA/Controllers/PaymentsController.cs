using PaymentSPA.Services;
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
        public string Get()
        {
            return 42.ToString();

        }

    }
}
