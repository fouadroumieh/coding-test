using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactor.Entities;
using Refactor.Services;

namespace Refactor
{
    public interface IOrderService
    {
        void AddToCart(Order order, string stockCode, int qty);
        void FillOrder(StockItem stockItem, int qty);
        void FillOrder(Order order);
        
    }
}
