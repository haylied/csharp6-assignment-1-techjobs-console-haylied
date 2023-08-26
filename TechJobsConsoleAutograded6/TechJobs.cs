using System;

namespace TechJobsConsoleAutograded6
{
	public class TechJobs
	{
        public void RunProgram()
        {
            // Create two Dictionary vars to hold info for menu and data

            // Top-level menu options
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
            actionChoices.Add("search", "Search");
            actionChoices.Add("list", "List");

            // Column options
            Dictionary<string, string> columnChoices = new Dictionary<string, string>();
            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");

            Console.WriteLine("Welcome to LaunchCode's TechJobs App!");

            // Allow user to search/list until they manually quit with ctrl+c
            while (true)
            {

                string actionChoice = GetUserSelection("View Jobs", actionChoices);

                if (actionChoice == null)
                {
                    break;
                }
                else if (actionChoice.Equals("list"))
                {
                    string columnChoice = GetUserSelection("List", columnChoices);

                    if (columnChoice.Equals("all"))
                    {
                        PrintJobs(JobData.FindAll());
                    }
                    else
                    {
                        List<string> results = JobData.FindAll(columnChoice);

                        Console.WriteLine(Environment.NewLine + "*** All " + columnChoices[columnChoice] + " Values ***");
                        foreach (string item in results)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else // choice is "search"
                {
                    // How does the user want to search (e.g. by skill or employer)
                    string columnChoice = GetUserSelection("Search", columnChoices);

                    // What is their search term?
                    Console.WriteLine(Environment.NewLine + "Search term: ");
                    string searchTerm = Console.ReadLine();

                    // Fetch results
                    if (columnChoice.Equals("all"))
                    {
                        Console.WriteLine(JobData.FindByValue(columnChoice));
                        //Console.WriteLine("Search all fields not yet implemented.");
                    }
                    else
                    {
                        List<Dictionary<string, string>> searchResults = JobData.FindByColumnAndValue(columnChoice, searchTerm);
                        PrintJobs(searchResults); // finding job info by column and value to print
                    }
                }

            }
        }

        /*
         * Returns the key of the selected item from the choices Dictionary
         */
        public string GetUserSelection(string choiceHeader, Dictionary<string, string> choices)
        {
            int choiceIdx;
            bool isValidChoice = false;
            string[] choiceKeys = new string[choices.Count]; // array of strings called choiceKeys set at the length of the choices dictionary

            int i = 0;
            foreach (KeyValuePair<string, string> choice in choices) // done for each choice in choices and placed in the choiceKeys array
            {
                choiceKeys[i] = choice.Key; // choiceKeys array at index[i] is equal to choice.Key (aka the keys is placed into array)
                i++;
            }

            do
            {
                if (choiceHeader.Equals("View Jobs"))
                {
                    Console.WriteLine(Environment.NewLine + choiceHeader + " by (type 'x' to quit):");
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + choiceHeader + " by:");
                }

                for (int j = 0; j < choiceKeys.Length; j++)
                {
                    Console.WriteLine(j + " - " + choices[choiceKeys[j]]); // j = the number , " - " , choices [ choiceKeys[j] ] (itll return the value)
                }

                string input = Console.ReadLine();
                if (input.Equals("x") || input.Equals("X"))
                {
                    return null;
                }
                else
                {
                    choiceIdx = int.Parse(input);
                }

                if (choiceIdx < 0 || choiceIdx >= choiceKeys.Length)
                {
                    Console.WriteLine("Invalid choices. Try again.");
                }
                else
                {
                    isValidChoice = true;
                }

            } while (!isValidChoice);

            return choiceKeys[choiceIdx];
        }

        // TODO: complete the PrintJobs method.
        public void PrintJobs(List<Dictionary<string, string>> someJobs) // list of jobs that contain Employer(key) and the ValueOfEmployer(value)
        {

            foreach (Dictionary<string, string> job in someJobs)// iterates over the list to the jobs(dictionaries)
            {

                if (true)
                {
                    Console.WriteLine("*****" + Environment.NewLine);

                    foreach (KeyValuePair<string, string> value in job) // stair stepping down into the dictionary
                    {



                        Console.WriteLine(value.Key + ": " + value.Value + Environment.NewLine);

                        //Console.WriteLine(value.job["position type"]+ ": " + value.Value + Environment.NewLine);

                        // Need This Order -

                        // 1. Postion Type:
                        // 2. Name:
                        // 3. Employer:
                        // 4. Location:
                        // 5. Core Competency:


                        Console.WriteLine("*****" + Environment.NewLine);
                        Console.WriteLine(Environment.NewLine);
                    }
                }

                Console.WriteLine("No Results");
            }
                
            
            //Console.WriteLine("PrintJobs is not implemented yet");
        }
    }
}
