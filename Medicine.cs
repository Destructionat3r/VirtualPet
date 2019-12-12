using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    class Medicine
    {
        public string Name { get; set; }
        public int Uses { get; set; }
        public int HealthIncrease { get; set; }
        public int HungerDecrease { get; set; }
        public int Price { get; set; }

        public Medicine(string name, int uses, int healthIncrease, int hungerDecrease, int price)
        {
            Name = name;
            Uses = uses;
            HealthIncrease = healthIncrease;
            HungerDecrease = hungerDecrease;
            Price = price;
        }

        public void Display(int number, int counter, bool shop)
        {
            Console.SetCursorPosition(54, counter);
            Console.WriteLine($"{number} {Name}");
            Console.SetCursorPosition(54, (counter += 1));
            Console.WriteLine($"  Uses: {Uses}");
            Console.SetCursorPosition(54, (counter += 1));
            Console.WriteLine($"  Health increase: {HealthIncrease}");
            Console.SetCursorPosition(54, (counter += 1));
            Console.WriteLine($"  Hunger decrease: {HungerDecrease}");
            if (shop == true)
            {
                Console.SetCursorPosition(54, (counter += 1));
                Console.WriteLine($"  Price: {Price}");
            }
        }
    }
}
