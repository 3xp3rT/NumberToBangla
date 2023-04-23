﻿using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace NumberToBangla
{
    public class NumberToBanglaGenerator
    {
        // An array of Bangla words representing digits from 0 to 99
        protected static string[] words = new string[] {
        "শূন্য",
        "এক",
        "দুই",
        "তিন",
        "চার",
        "পাঁচ",
        "ছয়",
        "সাত",
        "আট",
        "নয়",
        "দশ",
        "এগারো",
        "বারো",
        "তেরো",
        "চৌদ্দ",
        "পনেরো",
        "ষোল",
        "সতেরো",
        "আঠারো",
        "উনিশ",
        "বিশ",
        "একুশ",
        "বাইশ",
        "তেইশ",
        "চব্বিশ",
        "পঁচিশ",
        "ছাব্বিশ",
        "সাতাশ",
        "আঠাশ",
        "ঊনত্রিশ",
        "ত্রিশ",
        "একত্রিশ",
        "বত্রিশ",
        "তেত্রিশ",
        "চৌত্রিশ",
        "পঁয়ত্রিশ",
        "ছত্রিশ",
        "সাঁইত্রিশ",
        "আটত্রিশ",
        "ঊনচল্লিশ",
        "চল্লিশ",
        "একচল্লিশ",
        "বিয়াল্লিশ",
        "তেতাল্লিশ",
        "চুয়াল্লিশ",
        "পঁয়তাল্লিশ",
        "ছেচল্লিশ",
        "সাতচল্লিশ",
        "আটচল্লিশ",
        "ঊনপঞ্চাশ",
        "পঞ্চাশ",
        "একান্ন",
        "বাহান্ন",
        "তিপ্পান্ন",
        "চুয়ান্ন",
        "পঞ্চান্ন",
        "ছাপ্পান্ন",
        "সাতান্ন",
        "আটান্ন",
        "ঊনষাট",
        "ষাট",
        "একষট্টি",
        "বাষট্টি",
        "তেষট্টি",
        "চৌষট্টি",
        "পঁয়ষট্টি",
        "ছেষট্টি",
        "সাতষট্টি",
        "আটষট্টি",
        "ঊনসত্তর",
        "সত্তর",
        "একাত্তর",
        "বাহাত্তর",
        "তিয়াত্তর",
        "চুয়াত্তর",
        "পঁচাত্তর",
        "ছিয়াত্তর",
        "সাতাত্তর",
        "আটাত্তর",
        "ঊনআশি",
        "আশি",
        "একাশি",
        "বিরাশি",
        "তিরাশি",
        "চুরাশি",
        "পঁচাশি",
        "ছিয়াশি",
        "সাতাশি",
        "আটাশি",
        "ঊননব্বই",
        "নব্বই",
        "একানব্বই",
        "বিরানব্বই",
        "তিরানব্বই",
        "চুরানব্বই",
        "পঁচানব্বই",
        "ছিয়ানব্বই",
        "সাতানব্বই",
        "আটানব্বই",
        "নিরানব্বই"
        };


        /// <summary>
        /// This function takes one float money and returns their bangla money in word.
        /// </summary>
        /// <param name="number">Any float number (money)</param>
        /// <returns>The bangla money word</returns>
        public static string BanglaMoney(float number)
        {
            IsValid(number);

            if (number == 0)
            {
                return "শূন্য টাকা";
            }
            if (number.ToString().Contains("."))
            {
                return ConvertFloatNumberToMoneyFormat(number);
            }

            return BanglaWord((int)number) + " টাকা ";
        }


        /// <summary>
        /// This function takes one string number and returns their bangla comma with lakh in word.
        /// </summary>
        /// <param name="number">Any  number in string</param>
        /// <returns>The bangla ammount with comma in lakh </returns>
        public static string BanglaCommaLakh(string number)
        {
            IsValid(number);

            string n = Regex.Replace(number, @"(\d+?)(?=(\d\d)+(\d)(?!\d))(\.\d+)?", "$1,", RegexOptions.IgnoreCase);
            return BanglaNumber(n);
        }



        /// <summary>
        /// This function takes one string number and returns their bangla number.
        /// </summary>
        /// <param name="number">Any  number in string</param>
        /// <returns>The bangla number</returns>
        public static string BanglaNumber(string number)
        {
            IsValid(number);


            Dictionary<char, char> numbers = new Dictionary<char, char>()
            {
                {'0', '০'},
                {'1', '১'},
                {'2', '২'},
                {'3', '৩'},
                {'4', '৪'},
                {'5', '৫'},
                {'6', '৬'},
                {'7', '৭'},
                {'8', '৮'},
                {'9', '৯'},
            };

            StringBuilder sb = new StringBuilder();
            foreach (char c in number)
            {
                if (numbers.ContainsKey(c))
                {
                    sb.Append(numbers[c]);
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }



        /// <summary>
        /// This function takes one float number and returns their bangla in word.
        /// </summary>
        /// <param name="number">Any  number in float</param>
        /// <returns>The bangla word</returns>
        public static string BanglaWord(float number)
        {
            IsValid(number);

            var integerPart = (int)Math.Truncate(number);
            var decimalPart = (int)((number - integerPart) * 100);

            var text = ToWord(integerPart) + " দশমিক ";

            if (decimalPart > 0)
                text += ToWord(decimalPart);


            return text;
        }




        /// <summary>
        /// This function takes one int number and returns their bangla in word.
        /// </summary>
        /// <param name="num">Any integer number</param>
        /// <returns>The bangla word</returns>
        protected static string ToWord(int num)
        {
            string text = "";
            int crore = (int)(num / 10000000);
            if (crore != 0)
            {
                if (crore > 99)
                {
                    text += BanglaWord(crore) + " কোটি ";
                }
                else
                {
                    text += words[crore] + " কোটি ";
                }
            }

            int croreDiv = num % 10000000;

            int lakh = (int)(croreDiv / 100000);
            if (lakh > 0)
            {
                text += words[lakh] + " লক্ষ ";
            }

            int lakhDiv = croreDiv % 100000;

            int thousand = (int)(lakhDiv / 1000);
            if (thousand > 0)
            {
                text += words[thousand] + " হাজার ";
            }

            int thousandDiv = lakhDiv % 1000;

            int hundred = (int)(thousandDiv / 100);
            if (hundred > 0)
            {
                text += words[hundred] + " শত ";
            }

            int hundredDiv = thousandDiv % 100;
            if (hundredDiv > 0)
            {
                text += words[hundredDiv];
            }

            return text;
        }




        /// <summary>
        /// This function takes one float number and returns their bangla in word.
        /// </summary>
        /// <param name="number">Any float number</param>
        /// <returns>The bangla word</returns>
        protected static string ConvertFloatNumberToMoneyFormat(float number)
        {
            string money = number.ToString("0.00", CultureInfo.InvariantCulture);
            string[] decimalPart = money.Split('.');
            string text = (decimalPart[0]) + " টাকা ";
            if (decimalPart.Length > 1)
            {
                text += words[int.Parse(decimalPart[1])] + " পয়সা";
            }

            return text;
        }


        /// <summary>
        /// Convert number into English Month Name
        /// </summary>
        /// <param name="number"></param>
        /// <returns>string</returns>
        /// <exception cref="Exception"></exception>
        public string BanglaMonth(int number)
        {
            Dictionary<int, string> month = new Dictionary<int, string>
            {
                {1, "জানুয়ারি"},
                {2, "ফেব্রুয়ারি"},
                {3, "মার্চ"},
                {4, "এপ্রিল"},
                {5, "মে"},
                {6, "জুন"},
                {7, "জুলাই"},
                {8, "আগস্ট"},
                {9, "সেপ্টেম্বর"},
                {10, "অক্টোবর"},
                {11, "নভেম্বর"},
                {12, "ডিসেম্বর"}
            };

            if (int.TryParse(number.ToString(), out int n) && n >= 1 && n <= 12)
            {
                return month[n];
            }

            throw new Exception("Number should be between 1 and 12");
        }


        /// <summary>
        /// C# doesn't have a mixed data type, so we've used object instead.
        /// Also, C# doesn't have a preg_match function, so we've used the Regex.
        /// IsMatch method from the System.Text.RegularExpressions namespace instead. 
        /// Finally, we've used Convert.ToDecimal to convert the number to a decimal, since C# doesn't allow taking the absolute value of a non-numeric type.
        /// </summary>
        /// <param name="number"></param>
        /// <exception cref="Exception"></exception>
        protected static void IsValid(object number)
        {
            if (!(number is decimal || number is int || number is float || number is double)
                || Regex.IsMatch(number.ToString(), @"\.\d+\.")
                || Regex.IsMatch(number.ToString(), @"\d+E\d+")
               )
                throw new Exception("Invalid Number");


            if (Math.Abs(Convert.ToDecimal(number)) > 999999999999999)
                throw new Exception("Number should be less then 999999999999999");
        }
    }
}