using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;

public class try1
{
	public Class1()
	{
        static void compare0(string args)
        {
            IEnumerable<String> onlyfirst = lines1.Except(lines2);
            IEnumerable<String> onlysecond = lines2.Except(lines1);
            IEnumerable<String> shared = lines1.Except(onlyfirst);
            string first = "";
            string share = "";
            string second = "";
            foreach (string line in onlyfirst)
            {
                string[] words = line.Split(" ");
                foreach (string word in words)
                {
                    first += $"{word} ";
                }
            }
            foreach (string line in shared)
            {
                string[] words = line.Split(" ");
                foreach (string word in words)
                {
                    share += $"{word} ";
                }
            }
            foreach (string line in onlysecond)
            {
                string[] words = line.Split(" ");
                foreach (string word in words)
                {
                    second += $"{word} ";
                }
            }
            lock (lockobject)
            {
                foreach (string line in lines1)
                {
                    string[] words1 = line.Split(" ");
                    foreach (string word in words1)
                    {
                        if (share.Contains(word))
                        {
                            Console.Write($"{word} ");
                        }
                        else if (first.Contains(word))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{word} ");
                            Console.ResetColor();
                        }
                    }
                }
                foreach (string line in lines2)
                {
                    string[] words2 = line.Split(" ");
                    foreach (string word in words2)
                    {
                        if (!first.Contains(word) && !share.Contains(word))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{word} ");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }
    }
}
