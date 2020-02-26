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
        public static void Main(string[] args)
        {
            List<Country> Countries = new List<Country>();

            double CountryThreshold = Countries.Count * 0.55;
            double PopThreshold = 0.65;

            string Yes = "y";
            string No = "n";
            int YesVotes = 0;
            int NoVotes = 0;
            int PopVotes = 0;

            foreach(string item in Countries)
            {
                Countries.Add(new Country(Countries[i], Population[i])); // This instantiates an object for the Country and its population to be used for their vote
                Console.WriteLine($"{Countries[i]}, Population: , {Population[i]}, You may now vote Yes (y), No (n) or to Abstain your vote (a).");

                string UserInput = Console.ReadLine();
                if (String.Equals(UserInput, Yes))
                {
                    YesVotes++;
                    PopVotes += Population[i];
                    Console.WriteLine("You have voted yes.");

                }
                else (String.Equals(UserInput, No));
                {
                    NoVotes++;
                    Console.WriteLine("You have voted no.");
                }
            }
            
            if(YesVotes > CountryThreshold)
            {
                Console.WriteLine("The vote has finished in favour of passing the motion due to Country majority.");
            }
            if (PopVotes > PopThreshold)
            {
                Console.WriteLine("The vote has finished in favour of passing the motion due to Population majority.");
            }
            else
            {
                Console.WriteLine("The vote has finished and has been rejected.");
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            string[] CountryList = new string[] //Listed all of the country names for use later in the code.
            {
             "Austria",
             "Belgium",
             "Bulgaria",
             "Croatia",
             "Cyprus",
             "Czech Republic",
             "Denmark",
             "Estonia",
             "Finland",
             "France",
             "Germany",
             "Greece",
             "Hungary",
             "Ireland",
             "Italy",
             "Latvia",
             "Lithuania",
             "Luxemborg",
             "Malta",
             "Netherlands",
             "Poland",
             "Portugal",
             "Romania",
             "Slovakia",
             "Slovenia",
             "Spain",
             "Sweden",
             };

            Double[] CPopList = new double[] //Listed all of the country population values and in decimal form.
            {
             "1.98",
             "2.56",
             "1.56",
             "0.91",
             "0.20",
             "2.35",
             "1.30",
             "0.30",
             "1.23",
             "14.98",
             "18.54",
             "2.40",
             "2.18",
             "1.10",
             "13.65",
             "0.43",
             "0.62",
             "0.14",
             "0.11",
             "3.89",
             "8.49",
             "2.30",
             "4.34",
             "1.22",
             "0.47",
             "10.49",
             "2.29",
              
             };
        }
    }
}

