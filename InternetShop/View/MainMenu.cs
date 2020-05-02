using System;
using System.Collections.Generic;
using System.Text;
using InternetShop.Controller;
using InternetShop.Model;


namespace InternetShop.View {
    public class MainMenu {
        
        public readonly AppController controller;

        public MainMenu(AppController ctrl) => this.controller = ctrl;

        public string ViewMenu() {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Register");
            string selectOption = Console.ReadLine();
            return selectOption;
        }

        public User GetRegistrationInfo() {
                var unregistered = new User();
                Console.WriteLine("Provide Name");
                    string name = Console.ReadLine();
                    unregistered.Name = name;
                Console.WriteLine("Provide Surname");
                    string surname = Console.ReadLine();
                    unregistered.Surname = name;
                Console.WriteLine("Provide Email");
                    string email = Console.ReadLine();
                    unregistered.Email = name;
                Console.WriteLine("Provide Address");
                    string address = Console.ReadLine();
                    unregistered.Address = name;
            unregistered.Orders = null;
            return unregistered;
        }
        }
    }

