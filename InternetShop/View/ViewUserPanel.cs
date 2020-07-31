using System;
using InternetShop.Controller;
using InternetShop.Model;
// To do:
// return to main menu
namespace InternetShop.View {
    public class ViewUserPanel {

        private readonly User CurrentUser;

        public ViewUserPanel(AppController ctrl) => CurrentUser = ctrl.User;
        // Check if user is anonymous in order to now show his data
        
        public void ShowUserPanel() {
                Console.Clear();
                Console.WriteLine($"Welcome Back, {CurrentUser.Name}!");
                ShowUserInformation();
                Console.WriteLine("1. Your Cart");
                Console.WriteLine("2. Transaction History");
                Console.WriteLine("3. Logout");
        }
        public void ShowUserInformation() {
            Console.WriteLine("Your personal information");
            Console.WriteLine(
                $"{CurrentUser.Name}, " +
                $"{CurrentUser.Surname}, " +
                $"{CurrentUser.Email}, " +
                $"{CurrentUser.Address}");
        }
    }
}
