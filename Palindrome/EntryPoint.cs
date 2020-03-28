using System;
using static StringManipulation.StringUtilities;

namespace Palindrome
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a palindrome: ");
            string palindrome = Console.ReadLine();

            Console.WriteLine($"{Environment.NewLine}Is the string a palindrome?");
            Console.WriteLine($"<{IsPalindrome(palindrome)}>");
        }
    }
}