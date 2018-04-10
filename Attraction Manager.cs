using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attraction1
{
    public enum DaysOfWeeks
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };

    public enum Attractions
    {
        Batman,
        Swan,
        Pony,
        None
    };

    class AttractionManager
    {
        double cashbox;
        private List<Attractions> AllowedAttractionsByDay;
        int price;

        public AttractionManager(DaysOfWeeks dayOfWeek)
        {
            AllowedAttractionsByDay = new List<Attractions>();

            if (dayOfWeek == DaysOfWeeks.Monday || dayOfWeek == DaysOfWeeks.Wednesday ||
                 dayOfWeek == DaysOfWeeks.Friday)
            {
                AllowedAttractionsByDay.Add(Attractions.Batman);
            }
            if (dayOfWeek == DaysOfWeeks.Tuesday || dayOfWeek == DaysOfWeeks.Wednesday ||
                 dayOfWeek == DaysOfWeeks.Thursday)
            {
                AllowedAttractionsByDay.Add(Attractions.Swan);
            }
            if (dayOfWeek != DaysOfWeeks.Sunday)
            {
                AllowedAttractionsByDay.Add(Attractions.Pony);
            }
        }

        public List<Attractions> CheckAllowedAttractionsByDay()
        {
            return AllowedAttractionsByDay;
        }

        public bool EarnedEnought()
        {
            return cashbox >= 200;
        }

        public void ClosePark()
        {
            if (cashbox >= 200)
            {
                Console.WriteLine("Time to go home.");
            }
        }

        const int HEIGHT_FOR_BATMAN = 150;
        const int UPPER_HEIGHT_FOR_SWAN = 140;
        const int LOWER_HEIGHT_FOR_SWAN = 120;

        public Attractions LetKidTryHisLuck(Kid child)
        {
            Attractions allowedAttraction = Attractions.None;
            if (child.gender == Gender.Male && child.height >= HEIGHT_FOR_BATMAN && child.desiredAttraction == Attractions.Batman)
            {
                allowedAttraction = Attractions.Batman;
            }
            else if (child.gender == Gender.Female && child.height >= LOWER_HEIGHT_FOR_SWAN && child.height <= UPPER_HEIGHT_FOR_SWAN && child.desiredAttraction == Attractions.Swan)
            {
                allowedAttraction = Attractions.Swan;
            }
            else if (child.gender == Gender.Male && child.height <= UPPER_HEIGHT_FOR_SWAN && child.desiredAttraction == Attractions.Swan)
            {
                allowedAttraction = Attractions.Swan;
            }
            else if (child.desiredAttraction == Attractions.Pony)
            {
                allowedAttraction = Attractions.Pony;
            }
            if (AllowedAttractionsByDay.Contains(allowedAttraction))
            {
                return allowedAttraction;
            }
            return Attractions.None;
        }

        public int GetCostFor(Attractions attraction)
        {
            switch (attraction)
            {
                case Attractions.Batman:
                    price = 20;
                    break;
                case Attractions.Swan:
                    price = 10;
                    break;
                case Attractions.Pony:
                    price = 10;
                    break;
            }
            return price;
        }

        public void BuyTicket(Attractions attraction)
        {
            cashbox += GetCostFor(attraction);
        }
    }
}



