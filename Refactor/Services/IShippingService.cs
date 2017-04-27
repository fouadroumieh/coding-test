using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactor.Entities;

namespace Refactor
{
    public interface IShippingService
    {
        void ShipOrder(Order order);
        void ConfirmDelivery(Order order);
    }
}
