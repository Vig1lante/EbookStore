using System;
using System.Collections.Generic;
using System.Linq;
using InternetShop.Model;
using System.Reflection;
using System.Text.RegularExpressions;

namespace InternetShop.Controller {
    public class RegistrationController {
        public DbEntities Context { get; set; }

        public RegistrationController(DbEntities context) => this.Context = context;

        public User UserRegister(User user) {
            // Add user to database
            if (!ValidateRegistrationFailure(user)) {
                Context.User.Add(user);
                Context.SaveChanges();
                return user;
            }
            else {Console.WriteLine("Registration failed"); return null; }
        }
        public bool ValidateRegistrationFailure(User user) {
            // Main method for validating registration through sub-methods
            if (user != null
                && !RegisterCheckDuplicates(user)
                && !RegisterCheckWhiteSpace(user)
                && !IncorrectEmailFormat(user)
                && !RegisterPasswordIsBad(user)){ 
                return false;
            }
            return true;
        }

        private bool RegisterCheckDuplicates(User user) {
            // Check if registration name/surname already exists in database
            var checkNames = Context.User.Any(u => u.Name.Equals(user.Name) && u.Surname.Equals(user.Surname));
            if (checkNames) {
                Console.WriteLine("User already exists!");
                return true;
            }
            return false;
        }

        private bool RegisterCheckWhiteSpace(User user) {
            // Check for blank spaces in particular fields
            PropertyInfo[] properties = typeof(User).GetProperties();
            foreach (PropertyInfo property in properties) {
                if (property.PropertyType == typeof(string)) {
                    var currentCheck = (string) property.GetValue(user);
                    if (string.IsNullOrWhiteSpace(currentCheck)) {
                        Console.WriteLine("Sorry, this field cannot be empty");
                        return true;
                    }
                }
            } return false;
        }

        private bool RegisterPasswordIsBad(User user) {
            // regex for minimum 6 chars, minimum 2 digits, minimum 1 uppercase alpha
            string regMatchPasswordCriteria = "(?=^.{6,}$)(?=.*\\d{2,})(?=.*[A-Z])";
            Regex reg = new Regex(regMatchPasswordCriteria);
            bool checkPasswordReg = reg.IsMatch(user.Password)? true : false;
            if (!checkPasswordReg) {
                Console.WriteLine("Incorrect Passowrd"); 
                return true; 
            }
            return false;
        }
        public bool IncorrectEmailFormat(User user) {
            // regex for validating whether @ sign is present
            bool checkEmailReg = user.Email.Contains("@") ? true : false;
            if (!checkEmailReg) {
                Console.WriteLine("Invalid email format"); 
                return true; 
            }
            return false;
        }
    }
}
