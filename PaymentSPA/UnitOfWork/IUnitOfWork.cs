using PaymentSPA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSPA.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPaymentRepository PaymentRepository { get; set; }
        void Commit();
    }
}
