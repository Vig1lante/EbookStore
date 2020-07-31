using System;
using InternetShop.Model;
using System.Linq;
//using Alba.CsConsoleFormat;

namespace InternetShop.View {
    public class ViewProduct {

        public double TotalPrice { get; set; }
        static readonly int tableWidth = 100;
        //private readonly AppController _controller;
        private readonly MainMenu _mainMenu;
        public DbEntities Context { get; set; }
        public ViewProduct(DbEntities context, MainMenu MainMenu)
        {
            Context = context;
            _mainMenu = MainMenu;
        }

        public double GetTotalPrice(double price, int discount) {
            TotalPrice = Math.Round((price * (100 - discount) / 100), 2);
            return TotalPrice;
        }

        public void SearchProducts()
        {                                          
            Console.WriteLine("Enter search keyoword: ");
            string searchKeyword = Console.ReadLine();
            var searchQuery = Context.Product.Where(p => p.Title.ToLower().Contains(searchKeyword.ToLower()) || p.Author.ToLower().Contains(searchKeyword.ToLower()));
            if (searchQuery != null) {
                DisplayProducts(searchQuery);    // TODO nie działa :(:(:(
            } else {
                Console.WriteLine("No results found :(");
            }
        }
        
        public void ShowMenuCategories() {
            Console.WriteLine("\nSort by Category:\n");
            Console.WriteLine("1. Lifestyle.");
            Console.WriteLine("2. Romance.");
            Console.WriteLine("3. Medicine.");
            Console.WriteLine("4. Fantasy.");
            Console.WriteLine("5. Go back to product menu.");
        }

        public void SortProductCategory() {                     // TODO hashmap for categories
            Console.Clear();
            bool inputCheck = true;
            ShowMenuCategories();
            while (inputCheck) {
                string selectGenre = Console.ReadLine().ToUpper();
                Console.Clear();
                ShowMenuCategories();
                switch (selectGenre) {
                    case "1":
                        DisplayProducts(Context.Product.Where(g => g.Genre == "Lifestyle"));
                        break;
                    case "2":
                        DisplayProducts(Context.Product.Where(g => g.Genre == "Romance"));
                        break;
                    case "3":
                        DisplayProducts(Context.Product.Where(g => g.Genre == "medicine"));
                        break;
                    case "4":
                        DisplayProducts(Context.Product.Where(g => g.Genre == "Fantasy"));
                        break;
                    case "5":
                        DisplayProductMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again!");
                        break;
                }
            }
        }

        public void DisplayDiscountedProducts() {
            foreach (Product product in Context.Product.Where(p => p.Discount > 0))  {
                Console.WriteLine(product.Id.ToString() + " '" + product.Title + "'" + " by " + product.Author + ", " + GetTotalPrice(product.Price, product.Discount) + " - " + product.Discount + "% discount");
            }
        }

        public void DisplayProducts(IQueryable<Product> query) {            // TODO display 10 results - .Take(10))    Skip     + display sth if on sale
            PrintLine();
            PrintRow("ID", "Author", "Title", "Price");
            PrintLine();
            foreach (Product product in query) {
                PrintRow(product.Id.ToString(), product.Title, product.Author, GetTotalPrice(product.Price, product.Discount).ToString());
            }
            PrintRow("", "", "", "");
            PrintLine();
        }

         static void PrintLine() {
            Console.WriteLine(new string('-', tableWidth));
         }

        static void PrintRow(params string[] columns) {
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

        public void ShowMenuOptions() {
            Console.WriteLine("\nProduct Menu:\n");
            Console.WriteLine("* Press T to sort products by Title.");
            Console.WriteLine("* Press A to sort products by Author.");
            Console.WriteLine("* Press G to sort products by Genre.");
            Console.WriteLine("* Press S to search the catalog.");
            Console.WriteLine("* Press B to buy a product.");
            Console.WriteLine("* Press C to view your cart.");
            Console.WriteLine("* Press M to got back to main menu.\n");
        }

        public void DisplayProductMenu() {
            Console.Clear();
            bool inputCheck = true;
            Console.WriteLine("Products on sale right now:\n");
            DisplayDiscountedProducts();
            ShowMenuOptions();
            Console.WriteLine();
            DisplayProducts(Context.Product.Take(5));                   // TODO top 10 najczęściej zamawianych??

            while (inputCheck) {
                string selectOption = Console.ReadLine().ToUpper();
                Console.Clear();
                ShowMenuOptions();
                switch (selectOption) {
                    case "T":
                        DisplayProducts(Context.Product.OrderBy(t => t.Title));
                        break;
                    case "A":
                        DisplayProducts(Context.Product.OrderBy(a => a.Author));
                        break;
                    case "G":
                        SortProductCategory();
                        break;
                    case "S":
                        SearchProducts();
                        break;
                    case "C":
                        Console.WriteLine("show cart");               // TODO: implement cart display
                        break;
                    case "M":
                        _mainMenu.ViewMenu();
                        break;
                    case "B":                                                       // TODO: adding products
                        Console.WriteLine("Please provide product ID: ");           // TODO: żeby ksiązki nei znikały
                        string productInput = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again!");
                        break;
                }
            }
        }
    


        }
    }


