using System;

namespace StringManipulation
{
    public static class StringUtilities
    {
        private static char[] wordSeparators = { ' ', '.', ',', '|' };

        public static string InvertCase(string text)
        {
            char[] characters = text.ToCharArray();
            string resultingText = string.Empty;

            for (int index = 0; index < characters.Length; index++)
            {
                if (characters[index] >= 'A' && characters[index] <= 'Z')
                {
                    resultingText += characters[index].ToString().ToLower();
                }
                else if (characters[index] >= 'a' && characters[index] <= 'z')
                {
                    resultingText += characters[index].ToString().ToUpper();
                }
                else
                {
                    resultingText += characters[index];
                }
            }

            return resultingText;
        }

        public static string[] SplitIntoWords(string text)
        {
            string trimmedText = text.Trim();
            int numberOfWords = CountNumberOfWords(trimmedText);
            string[] words = new string[numberOfWords];

            if (numberOfWords == 0)
            {
                throw new InvalidOperationException("String is empty.");
            }

            int currentWord = 0;

            for (int i = 0; i < trimmedText.Length; i++)
            {
                if ((i < trimmedText.Length - 1)
                    && !((trimmedText[i] >= 'a' && trimmedText[i] <= 'z') || (trimmedText[i] >= 'A' && trimmedText[i] <= 'Z'))
                    && ((trimmedText[i + 1] >= 'a' && trimmedText[i + 1] <= 'z') || (trimmedText[i + 1] >= 'A' && trimmedText[i + 1] <= 'Z')))
                {
                    currentWord++;
                }
                else if ((trimmedText[i] >= 'a' && trimmedText[i] <= 'z') || (trimmedText[i] >= 'A') && trimmedText[i] <= 'Z')
                {
                    words[currentWord] += trimmedText[i];
                }
            }

            return words;
        }

        public static int CountNumberOfWords(string text)
        {
            int wordCounter;
            string trimmedText = text.Trim();


            if (text.Length == 0)
            {
                // Throwing an exception would also work here. 
                wordCounter = 0;
            }
            else
            {
                wordCounter = 1;
            }

            for (int i = 0; i < trimmedText.Length; i++)
            {
                if ((i < trimmedText.Length - 1)
                    && !((trimmedText[i] >= 'a' && trimmedText[i] <= 'z') || (trimmedText[i] >= 'A' && trimmedText[i] <= 'Z'))
                    && ((trimmedText[i + 1] >= 'a' && trimmedText[i + 1] <= 'z') || (trimmedText[i + 1] >= 'A' && trimmedText[i + 1] <= 'Z')))
                {
                    wordCounter++;
                }
            }

            return wordCounter;
        }

        public static int CalculateWordScore(string text)
        {
            int wordScore = 0;

            foreach (char character in text)
            {
                if (character >= 'A' && character <= 'Z')
                {
                    wordScore += (int)character - 64;
                }
                else if (character >= 'a' && character <= 'z')
                {
                    wordScore += (int)character - 96;
                }
            }

            return wordScore;
        }
    }
}