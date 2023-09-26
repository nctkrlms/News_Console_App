using NewsApp.Models;
using NewsApp.Models.Interfaces;
using NewsApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Controllers
{
    internal class NewsController : IProcess<New>
    {
        private NewsRepository _repositoryNew = new NewsRepository();
        private CategoryRepository _repositoryCat = new CategoryRepository();
        private CommentRepository _repositoryCom = new CommentRepository();
        private UserRepository _repositoryUser = new UserRepository();
        private CategoryController ctgryctrl = new CategoryController();
        public void Add()
        {
            Console.WriteLine("----------Add News----------");
            Console.WriteLine("--------------------------------");
            New news = new New();
            ctgryctrl.GetAll();
            Console.WriteLine("Enter News Category Id: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter News Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter News Content: ");
            string content = Console.ReadLine();


            if (!String.IsNullOrWhiteSpace(title) && !String.IsNullOrWhiteSpace(content))
            {
                news.Title = title;
                news.Content = content;
                news.CategoryId = categoryId;
                if (_repositoryNew.Add(news))
                {
                    Console.WriteLine("News Add Successful...");
                }
                else
                {
                    Console.WriteLine("News Add Failed...");
                }
            }
            else
            {
                Console.WriteLine("Please enter Correct Category...");
            }

        }

        public void Delete()
        {
            Console.WriteLine("-----------Delete New-----------");
            Console.WriteLine("----------------------------------");
            New news = Get();

            if (_repositoryNew.Delete(news.Id))
            {
                Console.WriteLine("Delete is success");
            }
            else
            {
                Console.WriteLine("Delete is failed..");
            }
        }

        public New Get()
        {
            GetAll();
            Console.WriteLine("----------Get News----------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Select News Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            New news = _repositoryNew.Get(id);
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("News ID: " + news.Id);
            Console.WriteLine("News Title: " + news.Title);
            Console.WriteLine("News Content: " + news.Content);
            Console.WriteLine("----------------------------------");
            GetNewAndComment(id);
            Console.WriteLine("Do you wanna add comment? (Press 1: YES, Press 2: NO.)");
            int select = Convert.ToInt32(Console.ReadLine());
            switch (select)
            {
                case 1:
                    Comment comment = new Comment();
                    Console.WriteLine("What is your comment: ");
                    comment.Content = Console.ReadLine();
                    comment.NewId = id;
                    comment.UserId = Program.userId;
                    if (_repositoryCom.Add(comment))
                    {
                        Console.WriteLine("Comment Add success.");
                    }
                    else
                    {
                        Console.WriteLine("Comment Add failed.");
                    }
                    break;
            }

            
            return news;
        }

        public void GetNewAndComment(int id)
        {
            
            
            Console.WriteLine("----------Comments----------");
            Console.WriteLine("----------------------------");
            var list = from news in _repositoryNew.GetAll()
                       join comment in _repositoryCom.GetAll()
                       on news.Id equals comment.NewId
                       join user in _repositoryUser.GetAll()
                       on comment.UserId equals user.Id
                       where news.Id == id
                       select new
                       {
                           id = comment.Id,
                           content = comment.Content,
                           user = user.Name +" "+user.Surname
                       };

            foreach (var items in list)
            {
                Console.WriteLine("----------------------------");

                Console.WriteLine("Comment Id: " + items.id);
                Console.WriteLine("Comment: " + items.content);
                Console.WriteLine("User: " + items.user);
                Console.WriteLine("----------------------------");

            }

        }

        public void GetAll()
        {
            Console.WriteLine("----------All News----------");
            Console.WriteLine("----------------------------------");
            var list = from cat in _repositoryCat.GetAll()
                       join news in _repositoryNew.GetAll()
                       on cat.Id equals news.CategoryId
                       select new
                       {
                           id = news.Id,
                           title = news.Title,
                           catName = cat.Name,
                           delete = news.IsDelete
                       };

            foreach (var news in list)
            {
                if(news.delete == false)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Category : " + news.catName);
                    Console.WriteLine("News ID: " + news.id);
                    Console.WriteLine("News Title: " + news.title);
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
                Console.WriteLine("---------- News Process ----------");
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
            New news = Get();
            Console.WriteLine("----------Update Category----------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Enter New Title: ");
            news.Title = Console.ReadLine();
            Console.WriteLine("Enter New Content: ");
            news.Content = Console.ReadLine();
            Console.WriteLine("Enter New CategoryId: ");
            news.CategoryId = Convert.ToInt32(Console.ReadLine());
            if (_repositoryNew.Update(news))
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
