using NewsApp.Models;
using NewsApp.Models.Interfaces;
using NewsApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Controllers
{
    internal class CategoryController : IProcess<Category>
    {
        private CategoryRepository repository = new CategoryRepository();

        public void Add()
        {
            Console.WriteLine("----------Add Category----------");
            Console.WriteLine("--------------------------------");
            Category category = new Category();
            Console.WriteLine("Enter Category Name: ");
            string name = Console.ReadLine();
            

            if (!String.IsNullOrWhiteSpace(name))
            {
                category.Name = name;
                if (repository.Add(category))
                {
                    Console.WriteLine("Category Add Successful...");
                }
                else
                {
                    Console.WriteLine("Category Add Failed...");
                }
            }
            else
            {
                Console.WriteLine("Please enter Correct Category...");
            }
            
        }

        public void Delete()
        {
            
            Console.WriteLine("-----------Delete Category-----------");
            Console.WriteLine("----------------------------------");
            Category category = Get();

            if (repository.Delete(category.Id))
            {
                Console.WriteLine("Delete is success");
            }
            else
            {
                Console.WriteLine("Delete is failed..");
            }


        }

        public Category Get()
        {
            GetAll();
            Console.WriteLine("----------Get Category----------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Select Category Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Category category = repository.Get(id);
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Category ID: " + category.Id);
            Console.WriteLine("Category Name: " + category.Name);
            Console.WriteLine("----------------------------------");
            return category;

            

        }

        public void GetAll()
        {
            Console.WriteLine("----------All Categories----------");
            Console.WriteLine("----------------------------------");

            foreach(Category category in repository.GetAll())
            {
                if(category.IsDelete == false)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Category ID: " + category.Id);
                    Console.WriteLine("Category Name: " + category.Name);
                    Console.WriteLine("----------------------------------");

                }
            }
        }

        public void Menu()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();
                Console.WriteLine("---------- Category Process ----------");
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
            Category category = Get();
            Console.WriteLine("----------Update Category----------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Enter New Name: ");
            category.Name = Console.ReadLine();
            if (repository.Update(category))
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
