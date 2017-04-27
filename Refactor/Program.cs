using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactor.Entities;
using Refactor.Services;

namespace Refactor
{
    class Program
    {
        /// <summary>
        /// An
        /// Refactor the system to allow better unit testability so that we can verify the email communications sent to the customer.
        /// Refactor any part as you see fit (create new objects, rename existing ones)
        /// Third party libraries or software should not be required with this excersize
        /// Replace manual steps of testing for emails marked with TODO with automated tests
        /// </summary>
        /// <param name="args"></param>
        /// *****************Solution Comment*********************
        /// Of course there is no need to check email inbox to verify if email sent or not, the system itself
        /// must either send the e-mail or not send it. The shipping service itself is not responsible to send emails
        /// (doesn't conform with SRP), but it can raise events that: hey, I've shipped an order now. Behind that
        /// the listeners/handlers can do the rest of the job and that's where the domain events comes into place. 
        /// So I've implemented a basic event named OrderShippingEvent which will be raised from the shipping service 
        /// after each order is shipped. Inside the OrderShippingHandler we can then the send the mail or 
        /// implement additional logic related.
        static void Main(string[] args)
        {
            var order = new Order()
            {
                EmailAddress = "eric.cartman@southpark.com"
            };

            var orderService = new OrderService();
            orderService.AddToCart(order, "DRML-3000-BR", 1);
            orderService.AddToCart(order, "SS-SSD-850-250", 3);
            
            Database.Instance.Add(order);

            var stockService = new StockService();

            stockService.StockReceived(new StockItem()
            {
                StockCode = "SS-SSD-850-250"
            });
            
            Assert(() => !order.Statuses.Contains(OrderStatus.EnRoute), "Expect order not to be shipped" );

            stockService.StockReceived(new StockItem()
            {
                StockCode = "SS-SSD-850-250"
            });

            Assert(() => order.Statuses.Contains(OrderStatus.EnRoute), "Expect order to be shipped");
        }

        static void Assert(Func<bool> assert, string error)
        {
            if (!assert())
            {
                throw new Exception(error);
            }
        }
    }


}
