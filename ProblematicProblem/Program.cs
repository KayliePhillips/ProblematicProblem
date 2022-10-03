using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Threading;




namespace ProblematicProblem
{
    internal class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag",
            "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Random rng = new Random();

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a " +
                "random activity? Yes/No: ");
            
                var answer = Console.ReadLine().ToLower();
            while (answer!= "yes" && answer != "no")
            {
                Console.WriteLine("Invalid answer.  Please answer yes or no.");
                answer = Console.ReadLine().ToLower();
            }
            
            if (answer == "no")
            {
                return;
            }
            
            //bool cont = bool.Parse(Console.ReadLine().ToLower());
            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();
            Console.Write("What is your age? ");
            bool userAgeParse = int.TryParse(Console.ReadLine(), out int userAge);
            
                while (userAgeParse != true)
                {
                    Console.WriteLine("Invalid input.  Please enter a number");
                    userAgeParse = int.TryParse(Console.ReadLine(), out userAge);
                }

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Yes/No: ");
                       
            var seeList = Console.ReadLine().ToLower();

            //bool seeList = bool.Parse(Console.ReadLine().ToLower());

            while (seeList != "yes" && seeList != "no")
            {
                Console.WriteLine("Invalid answer.  Please answer yes or no.");
                seeList = Console.ReadLine().ToLower();
            }

            if (seeList == "yes")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            
            Console.Write("Would you like to add any activities before we generate one? Yes/No: ");
            //bool addToList = bool.Parse(Console.ReadLine());
            Console.WriteLine();
            
            var addToList = Console.ReadLine().ToLower();

            while (addToList != "yes" && addToList != "no")
            {
                Console.WriteLine("Invalid answer.  Please answer yes or no.");
                addToList = Console.ReadLine().ToLower();
            }

            while (addToList == "yes")
            {
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();
                activities.Add(userAddition);
                Console.WriteLine();

                foreach (string activity in activities)
                {
                    Console.WriteLine($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();               
                Console.WriteLine("Would you like to add more? Yes/No: ");

                var userInput = Console.ReadLine().ToLower();

                addToList = userInput;
                while (addToList != "yes" && addToList != "no")
                {
                Console.WriteLine("Invalid answer.  Please answer yes or no.");
                addToList = Console.ReadLine().ToLower();
                }
                               
            }

            string anotherChoice = "redo";
            
            while (anotherChoice == "redo")
            {

                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.WriteLine(); 
                Console.Write("Choosing your random activity");
                


                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();


                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do wine tasting");
                    Console.WriteLine("Please pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    //string randomActivity = activities[randomNumber];
                }
                Console.WriteLine();
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! " +
                    $"Is this ok or do you want to grab another activity? Keep/Redo: ");
                anotherChoice = Console.ReadLine().ToLower();
                Console.WriteLine();
                //cont = bool.Parse(Console.ReadLine());

            }
            
            
            
        }


    }
}