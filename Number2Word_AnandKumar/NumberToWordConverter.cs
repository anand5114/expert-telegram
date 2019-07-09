////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: NumberToWordConverter.cs
//FileType: Visual C# Source file
//Author : Anand Kumar
//Created On : 7/10/2019 
//Last Modified On : 7/10/2019  
//Copy Rights : 
//Description : Class for converting number to word represention
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
namespace NumberToWord_AnandKumar
{
    /// <summary>
    /// Contains functionality to convert number to its word equivalant
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Start:
                long inputNumber;
                string outputWord = string.Empty;
                Console.WriteLine("Enter number to convert");
                bool isSucess = Int64.TryParse(Console.ReadLine(),out inputNumber);
                if (isSucess)
                {
                    outputWord = ConvertNumbertoWords(inputNumber);
                    Console.WriteLine(outputWord + " "+ "(press enter to continue..)");
                    
                }
                else
                {
                    Console.WriteLine("Invalid input..Provide a valid one" + " " + "(press enter to continue..)");
                }
                Console.ReadLine();
                goto Start;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        /// <summary>
        /// Converts given numbers to its word equivalant
        /// </summary>
        /// <param name="number">long number</param>
        /// <returns>string</returns>
        public static string ConvertNumbertoWords(long number)
        {
            string words = string.Empty;
            if (number == 0) return "zero";
           else if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
           else if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " million ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " thousand ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " hundred ";
                number %= 100;
            }
             
            if (number > 0)
            {
                if (words != "") words += "and ";
                var unitsMap = new[]
                {

                    "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
                };
                var tensMap = new[]
                {
                    "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
                };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}
