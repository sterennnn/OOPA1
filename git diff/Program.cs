using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;

namespace git_diff
{
    class program
    {
        public static void Main(string[] args)
        {
            string path1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"GitRepositories_1a.txt");
            string path2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"GitRepositories_1b.txt");
            string path3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"GitRepositories_2a.txt");
            string path4 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"GitRepositories_2b.txt");
            string path5 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"GitRepositories_3a.txt");
            string path6 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"GitRepositories_3b.txt");
            string[] paths = new string[] { path1, path2, path3, path4, path5, path6 }; //creates an array of the file paths to be chosen from
        q1:
            Console.WriteLine("Which file would you like to choose?");
            for (int i = 0; i < paths.Length; i++) //iterates through the choices displaying how to choose
            {
                Console.WriteLine($"To select {paths[i]} type {i}");
            }
            string Userinput = Console.ReadLine();
            int choice;
            if (!int.TryParse(Userinput, out choice)) //checks if the choice is a valid integer
            {
                if (choice < 0 || choice < 5)   //checks if the choice is within the range of values
                {
                    Console.WriteLine("Please select a valid option");
                    goto q1;
                }
            }
            else
            {
                choice = int.Parse(Userinput);
                Console.WriteLine($"You have selected {paths[choice]}");
            }
        q2:
            Console.WriteLine("Which file would you like to compare with");
            for (int i = 0; i < paths.Length; i++) //Shows the choices to the user again
            {
                Console.WriteLine($"To select {paths[i]} type {i}.");
            }
            int choice2;
            string Userinput2 = Console.ReadLine();
            if (!int.TryParse(Userinput2, out choice2)) //checks to see if the users second choice is a valid integer
            {
                    Console.WriteLine("Please select a different file to compare with.");
                    goto q2;
            }
            else
            {
                if (choice2 == choice || choice2 > 5 || choice2 < 0)    //checks if the choice is within the range of options and not the same as choice 1
                {
                    Console.WriteLine("Please select a different file to compare with.");
                    goto q2;
                }
                choice2 = int.Parse(Userinput2);
                Console.WriteLine($"You have selected {paths[choice]}");
            }
            comparing.compare(paths[choice], paths[choice2]); //Calls the compare function with the chosen files
        }
    }
    class comparing
    {
        public static void compare(string j, string k)
        {
            string[] lines1 = File.ReadAllLines(j); //
            string[] lines2 = File.ReadAllLines(k); //Instantiates arrays of the lines in both files
            var lines1and2 = lines1.Zip(lines2, (n, m) => new { line1 = n, line2 = m }); //Instantiates a 2d array containing both the lines from file a and file b
            if (lines1.Length == lines2.Length) //Checks and displays which lines have differences
            {
                for (int n = 0; n < lines1.Length; n++)
                {
                    if(lines1[n] != lines2[n])
                    {
                        Console.WriteLine($"The files differ on line {n}");
                    }
                }
            }
            foreach(var nm in lines1and2) //Iterates through the lines of both files simultaneously
            {
                int i = 0; //count for words on a line
                string[] words1 = nm.line1.Split(" ");  //
                string[] words2 = nm.line2.Split(" ");  //Splits the words on each line into their own arrays
                foreach(string word in words1)
                {
                    if (i < words1.Length)
                    {
                        if (words1[i] == words2[i]) //Checks if the words on the line are the same
                        {
                            Console.Write($"{words1[i]} ");
                            i++;
                        }
                        else if (!nm.line2.Contains(words1[i])) //Checks if a word has been taken away in file b and if so prints it in red and the word replacing it in green
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{words1[i]} ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{words2[i]} ");
                            Console.ResetColor();
                            i++;
                        }
                        else if (!nm.line1.Contains(words2[i])) //Checks if a words has been added to file b and prints it in green and the word that has been replaced in red
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{words2[i]} ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{words1[i]} ");
                            Console.ResetColor();
                            i++;
                        }
                    }
                }
            }
            Console.WriteLine("\n Press any key to close.");
            Console.ReadLine();
        }
    }
}

 
