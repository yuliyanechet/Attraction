using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Attraction1
{
    public enum Gender
    {
        Male,
        Female,
        Invalid
    };

    public class Kid
    {

        public string name;
        public double height;
        public Gender gender;
        public int happinessLevel;
        public int money;
        public Attractions desiredAttraction;

        public static Kid Create()
        {
            Kid newchild = new Kid();
            newchild.FillInputData();
            return newchild;
        }

        public void Cry()
        {
            height += 2;
            Console.WriteLine("Crying");
            Thread.Sleep(2000);
        }

        public void HaveFun()
        {
            happinessLevel += 100;
            Console.WriteLine("Having Fun");
        }

        public void FillInputData()
        {
            SetChildName();
            SetChildHeight();
            SetChildGender();
            SetMoneyAmount();
            SetDesiredAttraction();
        }

        public void SetChildName()
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine();
        }

        public void SetChildHeight()
        {
            do
            {
                Console.Write("Enter growth (in centimeters): ");
                try
                {
                    height = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (true);
        }

        public void SetChildGender()
        {
            do
            {
                Console.Write("Enter gender (M/F): ");
                string genderStr = Console.ReadLine();
                try
                {
                    switch (genderStr)
                    {
                        case "M":
                            gender = Gender.Male;
                            break;
                        case "F":
                            gender = Gender.Female;
                            break;
                        default:
                            throw new FormatException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Should be only 'M' or 'F'");
                }
            } while (true);
        }

        public void SetMoneyAmount()
        {
            do
            {
                Console.Write("Enter money amount (in $): ");
                try
                {
                    money = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (true);
        }

        public int GetMoney()
        {
            return money;
        }

        public void SetDesiredAttraction()
        {
            do
            {
                Console.Write("Enter desired attraction (Batman - 1, Swan - 2, Pony - 3): ");
                try
                {
                    int desiredAttractionAsNumber = Convert.ToInt32(Console.ReadLine());
                    switch (desiredAttractionAsNumber)
                    {
                        case 1:
                            desiredAttraction = Attractions.Batman;
                            return;
                        case 2:
                            desiredAttraction = Attractions.Swan;
                            return;
                        case 3:
                            desiredAttraction = Attractions.Pony;
                            return;
                        default:
                            throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Should be only 1, 2 or 3");
                }
            } while (true);
        }

        public void Refund(int price)
        {
            money = money - price;
        }
    }
}



