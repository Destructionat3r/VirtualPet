using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    class Toys
    {
        public string Name { get; set; }
        public int Uses { get; set; }
        public int MoodIncrease { get; set; }
        public int Price { get; set; }

        public Toys(string name, int uses, int moodIncrease, int price)
        {
            Name = name;
            Uses = uses;
            MoodIncrease = moodIncrease;
            Price = price;
        }

        public void Display(int number, int counter, bool shop)
        {
            Console.SetCursorPosition(54, counter);
            Console.WriteLine($"{number} {Name}");
            Console.SetCursorPosition(54, (counter += 1));
            Console.WriteLine($"  Uses: {Uses}");
            Console.SetCursorPosition(54, (counter += 1));
            Console.WriteLine($"  Mood increase: {MoodIncrease}");
            if (shop == true)
            {
                Console.SetCursorPosition(54, (counter += 1));
                Console.WriteLine($"  Price: {Price}");
            }
        }
    }
}
