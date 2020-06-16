using System;

namespace ConversionToBinary
{
    class EntryPoint
    {
        static void Main()
        {
            const int SIZE = 64;
            ulong value;
            char bit;

            Console.Write("Enter an integer: ");
            // Use long.Parse() to support negative numbers. 
            // Assumes unchecked assigment to ulong. 
            value = (ulong)long.Parse(Console.ReadLine());

            // Set initial mask to 100. 
            ulong mask = 1UL << SIZE - 1;
            for (int count = 0; count < SIZE; count++)
            {
                bit = ((mask & value) > 0) ? '1' : '0';
                Console.Write(bit.ToString());
                // Shift mask one location over to the right. 
                mask >>= 1;
            }
        }
    }
}