using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voting_Calculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string args)
        {
            List<Country> Countries = new List<Country>();

            double CountryThreshold = Countries.Count * 0.55;
            double PopThreshold = 0.65;
            
            foreach(string item in Countries)
            {
                Countries.Add(new Country(Countries[i], Population[i])); // This instantiates an object for the Country and its population to be used for their vote
                Console.WriteLine($"{Countries[i]}, {Population[i]")
            }

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
