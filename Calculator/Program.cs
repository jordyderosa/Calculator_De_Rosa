using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
  class Program
  {
    static void Main(string[] args)
    {
            //check if user is passing an argument
            Console.WriteLine("Welcome to the new calculator.Digit 'interactive' to enter in that mode or digit the path to the file txt you want to process.");
            string mode= Console.ReadLine();
           
            if (mode.Length > 0)
            {
                if (mode == "interactive")
                {
                    Console.WriteLine("Please insert the first argument: ");
                    var firstArgument = Console.ReadLine();

                    Console.WriteLine("Please insert the operation required (for Sum digit + , for Sub digit - , for multiply digit * , for divide digit /)");
                    var op = Console.ReadLine();

                    Console.WriteLine("Please insert the second argument: ");
                    var secondArgoument = Console.ReadLine();
                    makeOp(firstArgument,op,secondArgoument);
                }
                else
                {
                    var readAllText = System.IO.File.ReadAllText(mode);
                    var strings = readAllText.Split("\r\n".ToCharArray());
                   
                    makeOp(strings[0], strings[2], strings[4]);
                }
            }
            else
            {
                Console.WriteLine("No parameters passed. Digit 'interactive' to enter in that mode or digit the path to the file txt you want to process. Please try again.");
                Console.ReadKey();
            }
    }
        static void makeOp(string f,string op, string s)
        {
            var caseSwitch = op;

            switch (caseSwitch)
            {
                case "+":
                    Console.WriteLine("Result=" + (float.Parse(f) + float.Parse(s)));
                    break;
                case "-":
                        Console.WriteLine("Result=" + (float.Parse(f) - float.Parse(s)));
                    break;
                case "*":
                    Console.WriteLine("Result=" + (float.Parse(f) * float.Parse(s)));
                    break;
                case "/":
                    if (int.Parse(s) != 0)
                        Console.WriteLine("Result=" + (float.Parse(f) / float.Parse(s)));
                    else
                        Console.WriteLine("Second parameter should be grater than 0");
                    break;
                default:
                    Console.WriteLine("Operation not implemented yet or not recognized = " + op);
                    break;
            }
            Console.ReadKey();
        }
  }
}

