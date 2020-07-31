using InternetShop.Model;
using System;

namespace InternetShop.View {
    public class ViewLogin {

        private readonly DbEntities _context;
        public ViewLogin(DbEntities ctx) => this._context = ctx;
        // Returns a tuple with email pass for further validation
        public Tuple<string, string> GetLoginCredentials() {
            Console.WriteLine("Please provide your login information");
            Console.Write("Enter email: ");
            var email = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            return (new Tuple<string, string>(email, password));
        }

        public static void IncorrectLoginInformation() => Console.WriteLine("Incorrect user and/or password!");



    }
}
