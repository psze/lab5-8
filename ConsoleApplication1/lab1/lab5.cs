﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab5
{
    public class lab5
    {
        enum zero : long
        {
            million = 1000000,
            billion = 1000000000

        }
        public static string[][] name = new string[5][]{
                new string[] {
                    "","один ", "два ",
                    "три ", "четыре ", "пять ",
                    "шесть ", "семь ", "восемь ",
                    "девять "
                },
                new string[]{
                    "", "сто ", "двести ", "триста ", "четыреста ",
                    "пятьсот ", "шестьсот ", "семьсот ", "восемьсот ",
                    "девятьсот "
                },
                new string[]{
                    "десять ", "одиннадцать ","двенадцать ",
                    "тринадцать ","четырнадцать ","пятнадцать ",
                    "шестнадцать ","семнадцать ","восемнадцать ", "девятнадцать "
                },
                new string[]{
                    "", "", "двадцать ", "тридцать ", "сорок ",
                    "пятьдесят ", "шестьдесят ", "семьдесят ",
                    "восемьдесят ", "девяносто "
                },
                new string[] {
                    "тысяча ", "тысячи ", "тысяч ",
                    "миллион ", "миллиона ", "миллионов ",
                    "рубль ", "рубля ", "рублей "
                }
            };
        static public string SumInWords(long n)
        {
            string str = "", arr = (n.ToString());
            if (n >= (long)zero.million && n < (long)zero.billion)
            {
                str += number(n / (long)zero.million);
                if ((n / (long)zero.million) % 100 >= 10 && (n / (long)zero.million) % 100 < 20)
                {
                    str += name[4][2];
                }
                else
                {
                    switch ((n / (long)zero.million) % 10)
                    {
                        case 1: str += name[4][3]; break;
                        case 2:
                        case 3:
                        case 4: str += name[4][4]; break;
                        default: str += name[4][5]; break;
                    }
                }
                n %= (long)zero.million;
            }
            if (n >= 1000 && n < (long)zero.million)
            {
                if (n / 1000 == 1 || n / 1000 == 2)
                {
                    str += n / 1000 == 1 ? "одна " : "две ";
                }
                else
                {
                    str += number(n / 1000);
                }
                if ((n / 1000) % 100 >= 10 && (n / 1000) % 100 < 20)
                {
                    str += name[4][2];
                }
                else {
                    switch ((n / 1000) % 10)
                    {
                        case 1: str += name[4][0]; break;
                        case 2:
                        case 3:
                        case 4: str += name[4][1]; break;
                        default: str += name[4][2]; break;
                    }
                }
                str += number(n % 1000);
            }
            else
            {
                str += number(n);
            }
            if (n % 100 >= 10 && n % 100 < 20)
            {
                str += name[4][8];
            }
            else
            {
                switch (n % 10)
                {
                    case 1: str += name[4][6]; break;
                    case 2:
                    case 3:
                    case 4: str += name[4][7]; break;
                    default: str += name[4][8]; break;
                }
            }
            return str;
        }
        public static string number(long n)
        {
            string str = "";
            if (n >= 100 && n < 1000)
            {
                str += name[1][(n / 100)];
                n %= 100;
            }
            if (n >= 10 && n < 20)
            {
                str += name[2][(n % 10)];
                n %= 10;
            }
            else if (n >= 20 && n < 100)
            {
                str += name[3][(n / 10)];
                n %= 10;
                if (n >= 1 && n < 10)
                {
                    str += name[0][n];
                }
            }
            else if (n >= 1 && n < 10)
            {
                str += name[0][n];
            }
            return str;
        }
        public static void Main()
        {
            string str1 = "string 1";
            string str2 = new string('s', 5);
            char[] charray = { 's', 't', 'r' };
            string str3 = new string(charray);

            WriteLine($"{str1} - {str2} - {charray[0]} - {str3}");

            str2 = str1;
            str2 += " copy";
            WriteLine($"{str1[3]} - {str2} - {str1}");

            str1 = "I am student!!!";
            str2 = "people";
            var index = str1.IndexOf("student");
            str1 = str1.Remove(index, "student".Length);
            str1 = str1.Insert(index, str2);
            WriteLine($"{str1}");

            str1 = str1.Replace("people", "student");
            WriteLine($"{str1}");

            str1 = SumInWords(123456789);
            WriteLine($"{str1}");

            text("Текст текст, текст текст текст, текст");

            TestStringBuilder();

            PrintChar(new char[] { 'T', 'E', 'S', 'T' });

            string strin = CharArrayToString(new char[] { 'T', 'E', 'S', 'T' });
            WriteLine($"{strin}");

            WriteLine($"{IndexOfStr(new char[] { 't', 'e', 's', 't' }, new char[] { 's', 't', 'e', 's', 't' })}");
            ReadKey();
        }
        public static int IndexOfStr(char[] s1, char[] s2) // нахождение строки s1 в s2
        {
            string str1 = CharArrayToString(s1), str2 = CharArrayToString(s2);
            int i = str2.IndexOf(str1, 0);
            return i;
        }
        public static string CharArrayToString(char[] c)
        {
            string str = "";
            for (int i = 0; i < c.Length; i++)
            {
                str += c[i];
            }
            return str;
        }
        public static void PrintChar(char[] c)
        {
            for (int i = 0; i < c.Length; i++)
            {
                Write($"{c[i]} => ");
            }
            WriteLine();
        }
        public static void TestStringBuilder()
        {
            StringBuilder
                str1 = new StringBuilder("String – example of StringBuilder One"),
                str2 = new StringBuilder("String – example of StringBuilder Two");

            Write($"{str1}\n{str2}\n");

            str1.Insert(str1.Length, ", Текст вставки в конец");
            str2.Insert(0, "Текст вставки в начало, ");

            str1.Append(", TEXT");
            str2.Append(", TEXT 2");
            Write($"{str1}\n{str2}\n");

            string[] sub = (str1.ToString()).Split(',');
            int num = 0;
            foreach (var item in sub)
            {
                str2.AppendFormat("\n{0}: {1}", num++, item);
            }
            WriteLine($"{str2}");

            WriteLine($"{str1.Length} - {str1.Capacity} - {str1.MaxCapacity}");
            str1.EnsureCapacity(2000);
            WriteLine($"{str1.Length} - {str1.Capacity} - {str1.MaxCapacity}");
        }
        public static string text(string t)
        {
            string[] SimpleSentences;
            string[][] Words;

            SimpleSentences = t.Split(',');
            Words = new string[SimpleSentences.Length][];
            for (int i = 0; i < SimpleSentences.Length; i++)
            {
                Words[i] = SimpleSentences[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in SimpleSentences)
            {
                Write($"{item} == ");
            }
            WriteLine();
            foreach (var item in Words)
            {
                foreach (var i in item)
                {
                    Write($"{i} - ");
                }
            }
            WriteLine();
            string str = "";
            for (int i = 0; i < Words.Length; i++)
            {
                str += string.Join(" ", Words[i]);
                str += i == Words.Length - 1 ? "." : ", ";
            }

            WriteLine($"{str}");

            return str;
        }
    }
}