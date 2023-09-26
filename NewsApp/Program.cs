using NewsApp.AppDbContext;
using NewsApp.Controllers;
using NewsApp.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp
{
    internal class Program
    {
        public static int roleId = 2;
        public static int userId;
        static void Main(string[] args)
        {
            MainMenu();

        }
        public static void Menu(int id)
        {
            bool status = true;
            while (status)
            {
                Console.Clear();
                Console.WriteLine("--------Daily News App--------");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Please select what you gonna do?");
                Console.WriteLine("1. News Stuff");
                Console.WriteLine("2. Profile Stuff");
                if (id == 1)
                {
                    Console.WriteLine("3. Category Stuff");
                    Console.WriteLine("4. User Stuff");
                }
                Console.WriteLine("0. Quit");


                Console.WriteLine("Select: ");

                int select = Convert.ToInt32(Console.ReadLine());

                if (id == 1)
                {
                    Console.Clear();
                    switch (select)
                    {

                        case 0:
                            MainMenu();

                            break;
                        case 1:
                            NewsController ctrlNew = new NewsController();
                            ctrlNew.Menu();
                            break;
                        case 2:
                            UserController ctrlUser = new UserController();
                            ctrlUser.UserUpdate();
                            break;
                        case 3:
                            CategoryController ctrlCat = new CategoryController();
                            ctrlCat.Menu();
                            break;
                        case 4:
                            UserController ctrlUser2 = new UserController();
                            ctrlUser2.Menu();
                            break;
                        default: Console.WriteLine("Wrong Choice..."); break;
                    }
                    Console.ReadKey();
                }
                else if (id == 2)
                {
                    Console.Clear();
                    switch (select)
                    {
                        case 0:
                            status = false;

                            break;
                        case 1:
                            NewsController ctrlNew = new NewsController();
                            ctrlNew.Menu(); break;
                        case 2:
                            UserController ctrlUser = new UserController();
                            ctrlUser.UserUpdate();
                            break;
                        default: Console.WriteLine("Wrong Choice..."); break;
                    }
                }
                Console.ReadKey();


            }

        }
        public static void Login()
        {
            DataContext db = new DataContext();
            Console.Clear();
            Console.WriteLine("--------         Login         --------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("UserName: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            if (db.User.Any(x => x.Username == username && x.Password == password))
            {
                User user = db.User.FirstOrDefault(x => x.Username == username);
                roleId = user.RoleId;
                userId = user.Id;

                Menu(user.RoleId);
            }
            else
            {
                Console.WriteLine("User or Password Wrong...");
            }

        }
        public static void Register()
        {
            Console.Clear();
            Console.WriteLine("--------        Register       --------");
            Console.WriteLine("---------------------------------------");
            UserController userController = new UserController();
            userController.Add();
            Login();
        }

        public static void MainMenu()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();
                Console.WriteLine("------------DAILY NEWS APP----------");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. REGISTER");
                Console.WriteLine("2. LOGIN");
                int select = Convert.ToInt32(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 0:
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Wrong Choice...");
                        break;
                }
            }
        }
    }
}
