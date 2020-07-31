using InternetShop.Model;
using InternetShop.View;
using System;

namespace InternetShop.Controller {
    public class AppController {
        public DbEntities Context { get; set; }
        // Unregistered/Registered [Current] user
        public User User { get; set; } = new User(); // data in constructor
        public RegistrationController Regcontroller { get; set; }
        public LoginController Logincontroller { get; set; }
        public OrderController  OrderController;
        public ViewOrder ViewOrder;
        public ViewProduct ViewProduct { get; set; }
        public ViewUserPanel ViewUserPanel { get; }



        public AppController(DbEntities context) {
            this.Context = context;
            Regcontroller = new RegistrationController(context);
            // Create anonymous user for adding items to cart before logging in
            User.Anonymous = true;
            this.OrderController = new OrderController(context, this.User);
            this.ViewOrder = new ViewOrder(context, OrderController);
            MainMenu MainMenu = new MainMenu(this);
            this.ViewUserPanel = new ViewUserPanel(this);
            ViewProduct = new ViewProduct(context, MainMenu);
        }

        public User UserRegister(User user) {
            // Add user to database
            return Regcontroller.UserRegister(user);
        }

        public void UserLogin() {
            // Assign currently logged user to User field
            // if the user exists in db and auth process for login passed
            var getLoginInfo = new ViewLogin(Context);
            var controller = new LoginController(Context, getLoginInfo.GetLoginCredentials());
            var user = controller.GetAuthPassUser();
            if (controller.GetAuthPassUser() != null) {
                this.User = user;
            }
        }
        public void BrowseProducts()
        {
            Console.Clear();  
            ViewProduct.DisplayProductMenu();
           
        }

    }
}