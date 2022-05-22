using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTool
{
    class Menu : IMenu
    {
        private IBlogHandler _blogHandler;
        public Menu(IBlogHandler blogHandler){
            _blogHandler = blogHandler;
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
                Console.Write("Input: ");
                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        _blogHandler.BlogPost();
                        break;
                    case "2":
                        _blogHandler.BlogPostList();
                        break;
                    case "3":
                        _blogHandler.BlogPostSearch();
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
    }
}
