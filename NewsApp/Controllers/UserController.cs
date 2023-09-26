using NewsApp.Models;
using NewsApp.Models.Interfaces;
using NewsApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Controllers
{
    internal class UserController : IProcess<User>
    {
        private UserRepository _userRepository = new UserRepository();
        public void Add()
        {
            Console.WriteLine("----------Add User----------");
            Console.WriteLine("--------------------------------");
            User users = new User();
            _userRepository.GetAll();
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            int selRoleId = 2;
            if (Program.roleId == 1) {
                Console.WriteLine("Enter Users Role Id: ");
                selRoleId = Convert.ToInt32(Console.ReadLine());
            }
            

            if (!String.IsNullOrWhiteSpace(name) && !String.IsNullOrWhiteSpace(surname) && !String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                users.Name = name;
                users.Surname = surname;
                users.Username = username;
                users.Password = password;
                users.IsStatus = true;
                users.RoleId = selRoleId;
                if (_userRepository.Add(users))
                {
                    Console.WriteLine("User Add Successful...");
                }
                else
                {
                    Console.WriteLine("User Add Failed...");
                }
            }
            else
            {
                Console.WriteLine("You can't leave empty space");
            }
        }

        public void Delete()
        {
            Console.WriteLine("-----------Delete User-----------");
            Console.WriteLine("----------------------------------");
            User user = Get();

            if (_userRepository.Delete(user.Id))
            {
                Console.WriteLine("Delete is success");
            }
            else
            {
                Console.WriteLine("Delete is failed..");
            }
        }

        public User Get()
        {
            GetAll();
            Console.WriteLine("----------Get User----------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Select User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            User user = _userRepository.Get(id);
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("User ID      : " + user.Id);
            Console.WriteLine("User Name    : " + user.Name);
            Console.WriteLine("User Surname : " + user.Surname);
            Console.WriteLine("User RoleId : " + user.RoleId);
            Console.WriteLine("----------------------------------");
            return user;
        }

        public void GetAll()
        {
            Console.WriteLine("----------All Users----------");
            Console.WriteLine("----------------------------------");

            foreach (User user in _userRepository.GetAll())
            {
                if (user.IsDelete == false)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("User ID      : " + user.Id);
                    Console.WriteLine("User Name    : " + user.Name);
                    Console.WriteLine("User Surname : " + user.Surname);
                    Console.WriteLine("User RoleId : " + user.RoleId);
                    Console.WriteLine("----------------------------------");

                }
            }
        }
        public void UserUpdate()
        {
            Console.Clear();
            User user = _userRepository.Get(Program.userId);
            Console.WriteLine("---------- Profile Update -----------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(name))
            {
                user.Name = name;
            }
            Console.WriteLine("Enter Surname: ");
            string surname = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(surname))
            {
                user.Surname = surname;
            }
            Console.WriteLine("Enter New Username: ");
            string userName = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(userName))
            {
                user.Username = userName;
            }

            Console.WriteLine("Enter New Password: ");
            string password = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(password))
            {
                user.Password = password;
            }
            if (_userRepository.Update(user))
            {
                Console.WriteLine("Updated successful...");
            }
            else
            {
                Console.WriteLine("Update is not success...");
            }
            if (_userRepository.UserUpdate(user))
            {
                Console.WriteLine("Updated successful...");
            }
            else
            {
                Console.WriteLine("Update is not success...");
            }
            


        }

        public void Menu()
        {
            bool status = true;
            while (status)
            {

                Console.Clear();
                Console.WriteLine("---------- User Process ----------");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("----------- Select Process -----------");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Get");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. GetAll");
                Console.WriteLine("5. Delete");
                Console.WriteLine("0. Up Menu");
                Console.Write("Select: ");
                int select = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (select)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Get();

                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        GetAll();

                        break;
                    case 5:
                        Delete();

                        break;
                    case 0:
                        status = false;
                        return;
                    default:
                        Console.WriteLine("Wrong Choice... Please try again...");
                        break;
                }
                Console.ReadKey();


            }
        }
        public void Update()
        {
            User user = new User();
            user = Get();
            Console.WriteLine("---------- Update User ----------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(name))
            {
                user.Name = name;
            }
            Console.WriteLine("Enter Surname: ");
            string surname = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(surname))
            {
                user.Surname = surname;
            }
            Console.WriteLine("Enter New Username: ");
            string userName = Console.ReadLine();
            if(!String.IsNullOrWhiteSpace(userName))
            {
                user.Username = userName;
            }            
            
            Console.WriteLine("Enter New Password: ");
            string password = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(password))
            {
                user.Password = password;
            }
            if (_userRepository.Update(user))
            {
                Console.WriteLine("Updated successful...");
            }
            else
            {
                Console.WriteLine("Update is not success...");
            }
        }

    }
}
