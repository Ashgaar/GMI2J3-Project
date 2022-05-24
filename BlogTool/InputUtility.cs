using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTool
{
    public class InputUtility : IInputUtility
    {
        public string Input(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return input;
        }
    }
}
