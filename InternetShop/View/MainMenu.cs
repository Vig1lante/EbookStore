using System;
using InternetShop.Controller;

namespace InternetShop.View {
    public class MainMenu {

        public AppController Controller { get; set; }

        public MainMenu(AppController ctrl) => Controller = ctrl;

        private bool CheckIfNotAnonymous() => Controller.User.Anonymous ? true : false;

        public void ViewMenu() {
            bool inputCheck = true;
            Console.WriteLine("Welcome To The Online Shop!" +
                "\nMain Menu\n1. User panel\n2. Browse Products\n3. Exit\n");
            do {
                Console.Write("Enter: ");
                string selectOption = Console.ReadLine();
                switch (selectOption) {
                    case "1":
                        if (!CheckIfNotAnonymous()) {
                            Controller.ViewUserPanel.ShowUserPanel();
                            break;
                        }
                        else { 
                            UserPanelNotLoggedIn();
                            break;
                        }
                    case "2":
                        Controller.BrowseProducts();
                        inputCheck = false;
                        break;
                    case "3":
                        Console.WriteLine("Thanks for stopping by!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again!");
                        break;
                }
            }
            while (inputCheck);
        }

        private void MainLogin() {
            Controller.UserLogin(); ViewMenu(); 
        }

        private void MainRegister() {
            var register = new ViewRegistration(Controller);
            Controller.UserRegister(register.RegistrationLoopWhenInvalid());
            ViewMenu();
        }

        private void UserPanelNotLoggedIn() {
            Console.WriteLine("\nUser Panel\n1. Sign in\n2. Register a new account\n3. Return to menu");
            bool pleasedontstopthefunk = true;
            do {
                Console.Write("Enter: ");
                string selectOption = Console.ReadLine();
                if (selectOption.Equals("1")) {
                    MainLogin();
                    break;
                }
                else if (selectOption.Equals("2")) {
                    MainRegister();
                }
                else {
                    ViewMenu();
                }
            }
            while (pleasedontstopthefunk);
        }


    }
}
