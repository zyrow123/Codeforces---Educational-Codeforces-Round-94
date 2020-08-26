using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Contest95
{
    public class Question1
    {
        void Main(string[] args)
        {
            Logic(new CustomConsole());
        }

        public static void Logic(IConsole console)
        {
            int cases = Convert.ToInt32(console.ReadLine());


            for (int i = 0; i < cases; i++)
            {
                int value = Convert.ToInt32(console.ReadLine());
                string binaryString = console.ReadLine();
                console.WriteLine(CalculateBinaryString(value, binaryString));
            }
        }

        public static string CalculateBinaryString(int n, string bString)
        {
            var index = 1;
            var substrings = new List<string>();


            while (index <= n)
            {
                var subString = bString.Substring(index - 1, IndexAlgo(index, n) - (index - 1));
                substrings.Add(subString);

                index++;
            }

            var first = substrings.First();

            for (int count = 0; count < first.Length; count++)
            {
                var test = SimilarBinaryStrings(first, count);
                var match = true;

                foreach (var value in substrings.Skip(1))
                {
                    for (int i = 0; i < test.Length; i++)
                    {
                        if (test[i] == value[i])
                        {
                            break;
                        }

                        if (i + 1 == test.Length)
                        {
                            match = false;
                        }
                    }

                    if (match == false)
                    {
                        break;
                    }
                }

                if (match)
                {
                    return test;
                }
            }


            throw new Exception();
        }

        public static string SimilarBinaryStrings(string bString, int count)
        {
            if (count == 0)
            {
                return bString;
            }
            else if (count <= bString.Length)
            {
                var value = bString[count - 1] == '0' ? "1" : "0";

                return bString.Substring(0, count - 1) + value + bString.Substring(count, bString.Length - count);
            }

            return "";
        }

        public static List<string> SimilarBinaryStrings(string bString)
        {
            var result = new List<string> { bString };


            for (int i = 0; i < bString.Length; i++)
            {
                var value = bString[i] == '0' ? "1" : "0";


                result.Add( bString.Substring(0,i) + value + bString.Substring(i + 1, bString.Length - (i-1)));
            }

            return result;
        }

        public static int IndexAlgo(int index, int n)
        {
            return n + (index - 1);
        }

        public interface IConsole
        {
            string ReadLine();
            void WriteLine(string value);
        }

        public class CustomConsole : IConsole
        {
            public string ReadLine()
            {
                return Console.ReadLine();
            }

            public void WriteLine(string value)
            {
                Console.WriteLine(value);
            }
        }
    }


}
