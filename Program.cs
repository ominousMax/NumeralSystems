using System;

namespace NumeralSystems
{
    public static class Converter
    {
        public static void Main()
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int radix = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(GetRadix(number, radix));
        }

        public static string GetRadix(this int number, int radix)
        {
            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Incorrect radix.", nameof(number));
            }

            char[] buffer = new char[66];
            uint l;
            if (number < 0)
            {
                l = (radix == 10) ? (uint)-number : (uint)number;
            }
            else
            {
                l = (uint)number;
            }

            int index = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                uint div = l / (uint)radix;
                uint charVal = l - (div * (uint)radix);
                l = div;

                buffer[i] = (charVal < 10) ? (char)(charVal + '0') : (char)(charVal + 'A' - 10);

                if (l == 0)
                {
                    index = i + 1;
                    break;
                }
            }

            string result = null;
            for (int i = 0; i < index; i++)
            {
                result = string.Concat(result, buffer[index - i - 1]);
            }

            return result;
        }
    }
}
