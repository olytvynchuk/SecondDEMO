using System;
using System.Text.RegularExpressions;

namespace LearningCsharp
{
    public class Program
    {
         
        private string lastName;
        static void Main(string[] args)
        {
            
        }

        public static bool IsAlphabets(string inputString)
        {
            Regex r = new Regex("^[a-zA-Z ]+$");
            return r.IsMatch(inputString);
        }
        public string InputStringWithHandleExeption()
        {
            string inputString;
            while (true)
            {
                inputString = Console.ReadLine();
                if (IsAlphabets(inputString))
                {
                    return inputString;
                }
                else
                {
                    Console.WriteLine("Warning: Invalid input, this field should contain only letters!");
                }
            }
        }
    }
}