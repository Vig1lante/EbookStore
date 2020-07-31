using InternetShop.Model;
using InternetShop.View;
using System;
using System.Linq;

namespace InternetShop.Controller {
    public class LoginController {
        public DbEntities Context { get; set; }
        // assign field values from input (for email and password)
        private readonly string _emailEntry;
        private readonly string _passwordEntry;

        public LoginController(DbEntities context, Tuple<string, string> credentials) {
            this.Context = context; 
            // Assign tuple values from ViewLogin class to fields
            this._emailEntry = credentials.Item1; this._passwordEntry = credentials.Item2;
        }

        public User GetAuthPassUser() {
            // Return user if validation goes through or return null otherwise
            if (!ValidateLoginCredentials()) {
                ViewLogin.IncorrectLoginInformation();
                return null;
            }
            return Context.User.FirstOrDefault(u => u.Email.Equals(this._emailEntry));
        }

        private bool ValidateLoginCredentials() {
            // Main validation for existing email and proper password
            return ValidateEmailExists() && ValidateUserPassword();
        }

        private bool ValidateEmailExists() => Context.User.Any(e => e.Email.Equals(this._emailEntry));

        private bool ValidateUserPassword() {
            // compare passwords for given email
            return Context.User.Any(e => e.Email.Equals(this._emailEntry) && e.Password.Equals(this._passwordEntry));
        }
    }
}
