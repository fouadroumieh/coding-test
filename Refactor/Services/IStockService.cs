using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactor.Entities;

namespace Refactor.Services
{
    public interface IStockService
    {
        void StockReceived(StockItem stockItem);
        void StockAllocated(Order order, StockItem stockItem);
    }
}
