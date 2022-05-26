using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTool
{
    public class Menu : IMenu
    {
        private IBlogHandler _blogHandler;
        private IInputUtility _inputUtility;
        public Menu(IBlogHandler blogHandler, IInputUtility inputUtility)
        {
            _blogHandler = blogHandler;
            _inputUtility = inputUtility;
        }

        public void MainMenu()
        {
            Console.WriteLine("Hej och välkommen till Blogg-verktyget! ");
            Console.WriteLine("Välj i menyn vad du vill göra genom att ange siffran för ditt val följt av enter.");
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("\n-------------MENY-------------");
                Console.WriteLine("1 - Skapa nytt blogginlägg ");
                Console.WriteLine("2 - Se tidigare blogginlägg ");
                Console.WriteLine("3 - Sök tidigare blogginlägg ");
                Console.WriteLine("4 - Avsluta programmet ");

                string menuChoice = _inputUtility.Input("Val: ");

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        CreationMenu();
                        break;
                    case "2":
                        _blogHandler.BlogPostList();
                        break;
                    case "3":
                        Console.Clear();
                        SearchMenu();
                        break;
                    case "4":
                        Console.WriteLine("Avslutar programmet - Tack och hej!");
                        menu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Du måste ange en siffra mellan 1-4, försök igen! ");
                        break;
                }
            }
        }

        public void CreationMenu()
        {
            string title = _inputUtility.Input("Ange rubrik: ");
            string content = _inputUtility.Input("Inlägg: ");
            DateTime date = DateTime.Now;
            _blogHandler.BlogPost(title, content, date, "./SavedBlogPosts.json");

        }

        public void SearchMenu()
        {
            string search = _inputUtility.Input("Skriv titel: ");
            _blogHandler.BlogPostSearch(search);
        }
    }
}
