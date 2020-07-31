using System;
using System.Text.RegularExpressions;
using InternetShop.Controller;
using InternetShop.Model;

namespace InternetShop.View {
    public class ViewRegistration {

        public AppController Controller { get; }

        public ViewRegistration(AppController ctrl) => this.Controller = ctrl;
        // Takes user data through input and returns user object ready for registration controller validation
        public User GetRegistrationInfo() {
            var unregistered = new User();
            Console.Write("Provide Name > ");
            string name = Console.ReadLine();
            unregistered.Name = name;
            Console.Write("Provide Surname > ");
            string surname = Console.ReadLine();
            unregistered.Surname = surname;
            Console.Write("Provide Email > ");
            string email = Console.ReadLine();
            unregistered.Email = email;
            Console.WriteLine("Please provide a password with a minimum" +
                "6 length, 2 numbers and at least one upper-case letter");
            Console.Write("Provide Password > ");
            string password = Console.ReadLine();
            unregistered.Password = password;
            Console.Write("Provide Address > ");
            string address = Console.ReadLine();
            unregistered.Address = address;
            unregistered.Orders = null;
            return unregistered;
        }

        public User RegistrationLoopWhenInvalid() {
            // Loops over in registration if it is invalid, else returns user as null
            var user = Controller.Regcontroller.UserRegister(GetRegistrationInfo());
            while (user is null) {
                if (RegistrationCheckIfInvalidInput().Equals("y")) {
                    user = Controller.Regcontroller.UserRegister(GetRegistrationInfo());
                } else { break; }
            } return user;
        }

        public string RegistrationCheckIfInvalidInput() {
            // Checks in a loop whether input = y/n
            // Returns input;
            bool compareInput; string getInput;
            string stringCheck = "^(?:y|n)$";
            Regex reg = new Regex(stringCheck);
            Console.WriteLine("Would you like to try again? (y/n)");
            do {
                Console.Write("Provide your input: ");
                getInput = Console.ReadLine().ToLower();
                compareInput = reg.IsMatch(getInput);
                Console.WriteLine("Your input is : " + ((compareInput.Equals(true)) ? "valid" : "invalid"));
            } while (!compareInput);
            return getInput;
        }
    }
}
