namespace StringManipulation
{
    public static class StringUtilities
    {
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
    }
}