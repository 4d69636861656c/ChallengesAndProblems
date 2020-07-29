using System;
using System.IO;

namespace UsingFlagsAttribute
{
    class EntryPoint
    {
        static void Main()
        {
            string fileName = @"enumtest.txt";
            FileInfo file = new FileInfo(fileName);

            file.Open(FileMode.Create).Close();

            FileAttributes startingAttributes = file.Attributes;

            file.Attributes = FileAttributes.Hidden | FileAttributes.ReadOnly;

            Console.WriteLine("\"{0}\" outputs as \"{1}\"", file.Attributes.ToString().Replace(",", " |"), file.Attributes);

            FileAttributes attributes = (FileAttributes)Enum.Parse(typeof(FileAttributes), file.Attributes.ToString());

            Console.WriteLine(attributes);

            File.SetAttributes(fileName, startingAttributes);

            file.Delete();
        }
    }
}