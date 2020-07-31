using System;
using InternetShop.Controller;
using InternetShop.Model;

namespace InternetShop.View {
    public class ViewOrder
    {
        private readonly DbEntities _context;
        private readonly int tableWidth = 100;
        readonly OrderController _orderController;

        public ViewOrder(DbEntities context, OrderController orderController)
        {
            this._context = context;
            this._orderController = orderController;
        } 
        
        public void PrintAllProductsFromOrder(OrderController _orderController) {
            PrintLine();
            PrintRow("ID", "Author", "Title", "Price");
            PrintLine();
            foreach ( var orderLine in _orderController._order.OrderLines) {
                PrintRow(orderLine.Product.Id.ToString(),
                    orderLine.Product.Title,
                    orderLine.Product.Author, 
                    orderLine.Product.Price.ToString());
            }
            
            PrintLine();
            Console.WriteLine($"Total Price:  {_orderController._order.Price}");
            PrintLine();
            Console.WriteLine($"User/Customer: {_orderController._order.User.Name}");
            PrintLine();
            Console.ReadLine();
        }

        void PrintLine() {
            Console.WriteLine(new string('-', tableWidth));
        }
        
        void PrintRow(params string[] columns) {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns) {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }
        
        static string AlignCentre(string text, int width) {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            if (string.IsNullOrEmpty(text)) {
                return new string(' ', width);
            }
            else {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
