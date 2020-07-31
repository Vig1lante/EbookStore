using System;
using System.Linq;
using InternetShop.Model;

namespace InternetShop.Controller {
    public class OrderController : SystemException
    {
        public DbEntities Context { get; set; }
        public Order _order = new Order();
        private readonly User _user;

        public OrderController(DbEntities context, User user)
        {
            Context = context;
            //add user to implemented order
            _order.User = user;
            _user = user;
            _order.Status = Order.OrderStatus.Active;
            Context.Order.Add(_order);        // jesli user temp to != zapis else zapis (zapisuje do db)

        }

        public void AddProductToOrder(int productId)
        {
            Product productToAddToOrderLine = Context.Product.Find(productId);
            if (productToAddToOrderLine == null)
            {
                Console.WriteLine("Wrong number of product, try again");
            }
            else
            {
                OrderLine orderLine = new OrderLine
                {
                    Order = _order,
                    Product = productToAddToOrderLine
                };
                orderLine.Product = productToAddToOrderLine;
                _order.OrderLines.Add(orderLine);
                Context.Orderlines.Add(orderLine);
                SumPriceOfOrder();
            }
        }

        public void DeleteProductFromOrder(int productId)
        {
            Product productToDeleteFromOrder = Context.Product.Find(productId);
            if (productToDeleteFromOrder == null)
            {
                Console.WriteLine(" Wrong number of product");
            }
            else
            {
                _order.OrderLines = _order.OrderLines.Where(x => x.Product != productToDeleteFromOrder).ToList();
                Console.WriteLine($"Product {productToDeleteFromOrder.Title} was deleted from cart");
            }
        }
        
        
        public void SumPriceOfOrder()
        {
            var priceOfOrder = (
                from orderLine in _order.OrderLines
                select orderLine.Product.Price).Sum();
            _order.Price = Convert.ToUInt32(priceOfOrder);
        }

        public void ConfirmOrder()
        {
            _order.Status = Order.OrderStatus.Processed;
            _user.Orders.Add(_order);
            Context.Order.Update(_order); // adds possible anonymouis user to db
        }
        
    }
}