using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    class Food
    {
        public string Name { get; set; }
        public int HungerIncrease { get; set; }
        public int Price { get; set; }

        public Food()
        {

        }

        public Food (string name, int hungerIncrease, int price)
        {
            Name = name;
            HungerIncrease = hungerIncrease;
            Price = price;
        }

        public void Display(int number, int counter, bool shop)
        {
            Console.SetCursorPosition(54, counter);
            Console.WriteLine($"{number} {Name}");
            Console.SetCursorPosition(54, (counter += 1));
            Console.WriteLine($"  Hunger increase: {HungerIncrease}");
            if (shop == true)
            {
                Console.SetCursorPosition(54, (counter += 1));
                Console.WriteLine($"  Price: {Price}");
            }
        }
    }
}
