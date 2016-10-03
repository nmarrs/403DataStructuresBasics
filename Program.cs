/*
 * Data Structures Assignment
 * This program explores various data structures available in the C# language
 * 100 random customers are placed into a queue
 * Then a random number of burgers are generated and are added to the total for
 * each customer. The program then prints each customer and their total burgers eaten. 
 * 
 * Nathan Marrs
 * IS 403 Section 02
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatastructureBasics
{
    class Program
    {
        public static Random random = new Random();
        //Creating a new random object

        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }
        //This method returns a random name

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }
        //This method returns a random number 

        static void Main(string[] args)
        {
            Queue<string> custLine = new Queue<string>();
            //Creating queue to represent line of customers outside
            Dictionary<string, int> custInformation = new Dictionary<string, int>();
            //Creating dictionary to store information about each customer

            for (int i = 0; i < 100; i++)
            {
                custLine.Enqueue(randomName());
            }
            //Adding 100 customers to the queue using enqueue method

            IEnumerator<string> MyQueueEnumerator = custLine.GetEnumerator();
            //Creating enumerator to iterate over the customers in the queue

            while (MyQueueEnumerator.MoveNext())
            {
                 string custName = MyQueueEnumerator.Current;
                 //Assigning string custName from location in the queue
                 if (custInformation.ContainsKey(custName) == false)
                {
                    custInformation.Add(custName, 0);
                    //Creating new dictionary entry from queue
                }
                //Creating new dictionary entry if one has not been made yet
                
                int iRandom = randomNumberInRange();
                iRandom += custInformation[custName];
                custInformation[custName] = iRandom;
                //Adding random number of burgers to each customer 
                //This code increments to account for past customer visits
            }
            //While loop that adds queue information to a dictionary
            //Then assigns number of burgers to each related customer in dictionary

            Console.WriteLine("Customer name\t\t  Number of burgers\n");
            //Displaying column headers 

            foreach (KeyValuePair<string, int> cID in custInformation)
            {
                Console.WriteLine(cID.Key + "\t\t\t" + cID.Value);
            }
            //Foreach loop that prints out each dictionary value pair present

            Console.WriteLine("\nPress enter to exit");
            Console.ReadLine();
            //Letting user know how to exit program
        }
    }
}
