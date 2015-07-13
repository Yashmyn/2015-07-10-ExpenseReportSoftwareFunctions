using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015_07_10_ExpenseReportSoftwareFunctions
{    //a particular goal of this code: minimize the amount of input the user must enter befoe he possily learns his expense report will be rejected; so if he enters "entertainment" or "towncar", he's notified, before being asked to input cost, that his report is rejected.

    //assumptions:
    //(1.) what can be approved IS approved;
    //(2.) managers currently decide to reject requests only for the reasons expressly stated in the lab instructions;
    //(3.) everyone's expense report is reviewed beginning at the first level; and
    //(4.) this CEO will consider anything that has not been rejected pursuant to managers' rules.


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("***EXPENSE REPORT***");

            //call function to get user description
            string description = GetDescription();

            //call function to check for entertainment or towncar entries
            bool entertTownCarRejected = EntertTownCarReview(description);
            if (entertTownCarRejected)
                goto Finish;

            //call function to get cost from user
            double expenseAmount = GetCost(description);

            if (description == "hardware")
            {
                //call function to check for hardware > $5,000
                bool hardwareRejected = HardwareReview(expenseAmount);
                if (hardwareRejected)
                    goto Finish;
            }
            //call function to do manager-level expense-amount review
            MgtReviewResults(expenseAmount);

        Finish:
            Console.ReadLine();
        }

        static string GetDescription()
        {
            Console.WriteLine();
            Console.Write("DESCRIPTION of item to be expensed: ");
            string description = Console.ReadLine();
            return description;
            Console.WriteLine();
        }

        static bool EntertTownCarReview(string description)
        {
            bool entertTownCarRejected = true;
            Console.WriteLine();

            if (description == "entertainment")
                Console.Write("REJECTED - the company is currently not expensing entertainment.");

            else if ((description == "towncars") || (description == "towncar") || (description == "town cars") || (description == "town car"))
                Console.Write("REJECTED - the company is currently not expensing towncars.");

            else entertTownCarRejected = false;
            return entertTownCarRejected;
        }

        static double GetCost(string description)
        {
            Console.Write("COST of the " + description + ": ");
            double expenseAmount = double.Parse(Console.ReadLine());
            return expenseAmount;
        }

        static bool HardwareReview(double expenseAmount)
        {
            bool hardwareRejected = false;
            if (expenseAmount > 5000)
            {
                hardwareRejected = true;
                Console.WriteLine();
                Console.Write("REJECTED - the company is currently not expensing hardware purchases over $5,000.");
            }
            return hardwareRejected;
        }

        static void MgtReviewResults(double expenseAmount)
        {
            if (expenseAmount <= 250)
                Console.WriteLine("Your expense has been approved by a first-level manager.");

            else if ((expenseAmount > 250) && (expenseAmount <= 500))
                Console.WriteLine("Your expense has been approved by a second-level manager.");

            else if ((expenseAmount > 500) && (expenseAmount <= 1000))
                Console.WriteLine("Your expense has been approved by a director.");

            else
                Console.WriteLine("The CEO is considering your request.");
        }
    }
}
