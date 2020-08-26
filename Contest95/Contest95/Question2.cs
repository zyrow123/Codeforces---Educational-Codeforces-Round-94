using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Contest95
{
    public class Question2
    {
        static void Main(string[] args)
        {
            Logic(new CustomConsole());
        }

        public static void Logic(IConsole console)
        {
            int cases = Convert.ToInt32(console.ReadLine());

            for (int i = 0; i < cases; i++)
            {
                string binaryString = console.ReadLine();
                int value = Convert.ToInt32(console.ReadLine());
                console.WriteLine(CalculateBinaryString(value, binaryString));
            }
        }

        public static string CalculateBinaryString(int n, string bString)
        {
            var w = new string[bString.Length];

            for (int i = 0; i < bString.Length; i++)
            {
                if (bString[i] == '1')
                {
                    if (i - n >= 0)
                    {
                        if (w[i - n] == null)
                        {
                            w[i - n] = "1";
                            continue;
                        }
                        else if (w[i - n] == "0")
                        {
                            return "-1";
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (i + n < bString.Length)
                    {
                        if (w[i + n] == null)
                        {
                            w[i + n] = "1";
                        }
                        else if (w[i + n] == "0")
                        {
                            return "-1";
                        }
                    }
                }

                if (bString[i] == '0')
                {
                    if (i - n > 0)
                    {
                        if (w[i - n] == null)
                        {
                            w[i - n] = "0";
                        }
                        else if (w[i - n] == "1")
                        {
                            return "-1";
                        }
                    }

                    if (i + n < bString.Length)
                    {
                        if (w[i + n] == null)
                        {
                            w[i + n] = "0";
                        }
                        else if (w[i + n] == "1")
                        {
                            return "-1";
                        }
                    }
                }
            }

            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] == null)
                {
                    w[i] = "1";
                }
            }

            return string.Join(null,w);
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


                result.Add(bString.Substring(0, i) + value + bString.Substring(i + 1, bString.Length - (i - 1)));
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
