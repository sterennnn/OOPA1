using System;
using System.Collections.Generic;
using System.Linq;

namespace Voting_Calculator
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string[] Countries = new string[] //Listed all of the country names for use later in the code.
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

            Double[] Population = new double[] //Listed all of the country population values and in decimal form.
            {
             1.98,
             2.56,
             1.56,
             0.91,
             0.20,
             2.35,
             1.30,
             0.30,
             1.23,
             14.98,
             18.54,
             2.40,
             2.18,
             1.10,
             13.65,
             0.43,
             0.62,
             0.14,
             0.11,
             3.89,
             8.49,
             2.30,
             4.34,
             1.22,
             0.47,
             10.49,
             2.29,

             };

            int CountryCount = Countries.Count(); //Creates value to be used for the amount of countries
            double CountryThreshold = CountryCount * 0.55; //Calculates the amount of countries necessary for a vote to be passed
            double PopThreshold = 0.65; //Establishes the percentage of population required for a vote to be passed

            string Yes = "y"; //Creates string containing the response for yes to check against
            string No = "n"; //Creates string containing the response for no to check against
            int YesVotes = 0; //Establishes a counter for yes votes
            int NoVotes = 0; //Establishes a counter for no votes
            double PopVotes = 0; //Establishes the counter for the percentage of population voting yes

            for(int i = 0; i < CountryCount; i++) //Iterates through the list of countries and Population
            {
                Console.WriteLine($"{Countries[i]}, Population: , {Population[i]}, You may now vote Yes (y), No (n) or to Abstain your vote (a)."); //Displays the country and population for the country that is voting

                string UserInput = Console.ReadLine(); //Reads the input from the user for their answer
                if (String.Equals(UserInput, Yes)) //Checks if the user has voted yes
                {
                    YesVotes++; //Adds a yes vote to the count
                    PopVotes += Population[i]; //Adds the percentage of the population from the voting country to the count
                    Console.WriteLine("You have voted yes."); 

                }
                if (String.Equals(UserInput, No)) //Checks if the user voted no
                {
                    NoVotes++; //Adds a no vote to the count
                    Console.WriteLine("You have voted no.");
                }
            }
            double CountryPercent = 100*(YesVotes / CountryCount); //Calculates the percentage of votes that were yes
            
            if (YesVotes > CountryThreshold)
            {
                Console.WriteLine($"The vote has finished in favour of passing the motion due to Country majority. {CountryPercent}% countries voted yes");
                
            }
            if (PopVotes > PopThreshold)
            {
                Console.WriteLine($"The vote has finished in favour of passing the motion due to Population majority. {PopVotes}% population voted yes");
            }
            else
            {
                Console.WriteLine("The vote has finished and has been rejected.");
            }


        }
    }

    internal class Country
    {
    }
}

