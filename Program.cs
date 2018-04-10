using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attraction1
{


    class Program
    {
        static DaysOfWeeks GetDayOfWeek()
        {
            do
            {
                try
                {
                    Console.Write("Please enter day of week (Monday = 1, Tuesday = 2, etc...): ");
                    return (DaysOfWeeks)Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Your input is invalid. Should be only integer");
                }

            } while (true);
        }

        static int GetClassSize()
        {
            do
            {
                try
                {
                    Console.Write("Please enter number of children: ");
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Your input is invalid. Number of children should be only integer");
                }
            } while (true);
        }

        static void PrintResult(Kid child)
        {
            Console.WriteLine("Happiness result for {0} is: {1}", child.name, child.happinessLevel);
            Console.WriteLine("Money left: {0}", child.money);
        }

        static void Main(string[] args)
        {
            var today = GetDayOfWeek();
            AttractionManager am = new AttractionManager(today);

            if (am.CheckAllowedAttractionsByDay().Count > 0)
            {
                List<Kid> listOfChildrens = new List<Kid>();

                int size = GetClassSize();

                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Enter info about {0} child", i + 1);
                    Kid kid = Kid.Create();
                    listOfChildrens.Add(kid);
                }
                List<Kid> listForReport = listOfChildrens.ToList();

                while (!am.EarnedEnought() && listOfChildrens.Count > 0)
                {
                    List<Kid> kidsWithoutMoney = new List<Kid>();

                    foreach (var child in listOfChildrens)
                    {
                        Attractions attraction = am.LetKidTryHisLuck(child);
                        if (attraction == Attractions.None)
                        {
                            child.Cry();
                            continue;
                        }

                        if (am.GetCostFor(attraction) <= child.GetMoney())
                        {
                            am.BuyTicket(attraction);
                            child.Refund(am.GetCostFor(attraction));
                            child.HaveFun();
                        }
                        else
                        {
                            Console.WriteLine("No money for fun! Go and suck a dick");
                            kidsWithoutMoney.Add(child);
                        }
                        if (am.EarnedEnought())
                        {
                            am.ClosePark();
                            break;
                        }
                    }
                    listOfChildrens = listOfChildrens.Except(kidsWithoutMoney).ToList();
                }
                foreach (var item in listForReport)
                {
                    PrintResult(item);
                }
            }
            else
            {
                Console.WriteLine("No attractions are allowed today.");
            }

            Console.ReadKey();
        }
    }
}




