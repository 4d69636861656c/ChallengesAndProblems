using System;
using static StringManipulation.StringUtilities;

// Demonstrates how to separate the individual words in a random string and calculate which word has the highest score.
// The score of a character is calculated by taking the order in the English alphabet of a letter.
//The score of a word is the sum of the score of each letter in a word. 
//The highest score word is returned from the given string.

namespace WordScore
{
    class EntryPoint
    {
        static void Main()
        {
            DoWork();
        }

        private static void DoWork()
        {
            string text = "   This, this is ... A random string! I hope this program will compile and run. \\0/   ";
            Console.WriteLine($"The given string is: \"{text}\"");

            Console.WriteLine($"The string has {CountNumberOfWords(text)} words.");

            string[] words = SplitIntoWords(text);

            Console.WriteLine("The words and their calculated points are as follows: ");
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"{i + 1}. The word \"{words[i]}\", with an associated score of {CalculateWordScore(words[i])}.");
            }

            // Compare scores and decide the winner. 
            int score = 0;
            int position = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (CalculateWordScore(words[i]) > score)
                {
                    score = CalculateWordScore(words[i]);
                    position = i;
                }
            }

            Console.WriteLine($"The word with the highest score is \"{words[position]}\", with a score of {CalculateWordScore(words[position])} points.");
        }
    }
}