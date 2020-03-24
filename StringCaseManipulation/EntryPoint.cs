﻿using System;
using static StringManipulation.StringUtilities;

namespace StringManipulation.InvertCase
{
    class EntryPoint
    {
        static void Main()
        {
            string text = "Lorem Ipsum Dolor Sit Amet, Consectetur Adipiscing Elit, Sed Do Eiusmod Tempor Incididunt Ut Labore Et Dolore Magna Aliqua. " +
                          "Ut Enim Ad Minim Veniam, Quis Nostrud Exercitation Ullamco Laboris Nisi Ut Aliquip Ex Ea Commodo Consequat. " +
                          "Duis Aute Irure Dolor In Reprehenderit In Voluptate Velit Esse Cillum Dolore Eu Fugiat Nulla Pariatur. " +
                          "Excepteur Sint Occaecat Cupidatat Non Proident, Sunt In Culpa Qui Officia Deserunt Mollit Anim Id Est Laborum.";
            Console.WriteLine($"Initial text: {System.Environment.NewLine}\"{text}\"");

            string invertedText = StringUtilities.InvertCase(text);
            Console.WriteLine($"Reversed case: {System.Environment.NewLine}\"{invertedText}\"");
        }
    }
}