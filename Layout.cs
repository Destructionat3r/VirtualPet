using System;
using System.IO;

namespace VirtualPet
{
    public class Layout : IRealTimeComponent
    {
        public int displayMenu = 1;
        public string choice = "Menu";
        public string page = " ";
        public int pageNo = 1;
        string clear = " ";
        char[,] layout = new char[28, 78];
        string[] lines = File.ReadAllLines("Layout.txt");
        Shop shop = new Shop();
        Inventory inv = new Inventory();

        public void Display()
        {
            string menu = "";

            for (int row = 0; row < layout.GetLength(0); row++)
            {
                for (int column = 0; column < layout.GetLength(1); column++)
                {
                    if (layout[row, column] != ' ')
                    {
                        Console.SetCursorPosition(column, row);
                        Console.Write(layout[row, column]);
                    }
                }
                Console.WriteLine();
            }

            for (int i = 4; i <= 26; i++)
            {
                Console.SetCursorPosition(54, i);
                Console.WriteLine(clear.PadRight(21));
            }
            Console.SetCursorPosition(54, 2);
            Console.WriteLine(choice.PadRight(21));

            switch (displayMenu)
            {
                case 1:
                    for (int i = 4; i <= 22; i++)
                    {
                        Console.SetCursorPosition(54, i);

                        menu = i switch
                        {
                            4 => "1 - Shop",
                            5 => "2 - Inventory",
                            15 => "Up - Increase Temp",
                            16 => "Down - Decrease Temp",
                            _ => " ",
                        };
                        Console.WriteLine(menu);
                    }
                    break;
                case 2:
                    for (int i = 4; i <= 22; i++)
                    {
                        Console.SetCursorPosition(54, i);

                        menu = i switch
                        {
                            4 => "1 - Food",
                            5 => "2 - Medicine",
                            6 => "3 - Toys",
                            _ => " ",
                        };
                        Console.WriteLine(menu);
                    }
                    break;
                case 3:
                    if (choice == "Shop")
                    {
                        shop.Display(page, pageNo);
                    }
                    if (choice == "Inventory")
                    {
                        inv.Display(page, pageNo);
                    }
                    break;
            }
            if (displayMenu == 1)
            {
                Console.SetCursorPosition(54, 25);
                Console.WriteLine("Esc - Quit");
            }
            else
            {
                Console.SetCursorPosition(54, 25);
                Console.WriteLine("Esc - Go Back");
            }

            Console.SetCursorPosition(3, 21);
            Console.WriteLine("Health:");

            Console.SetCursorPosition(29, 21);
            Console.WriteLine("Mood:");

            Console.SetCursorPosition(3, 23);
            Console.WriteLine("Hunger:");

            Console.SetCursorPosition(29, 23);
            Console.WriteLine("Gold:");

            Console.SetCursorPosition(3, 25);
            Console.WriteLine("Current Temp:");

            Console.SetCursorPosition(29, 25);
            Console.WriteLine("Target Temp:");
        }

        public void Initialise()
        {
            for (int row = 0; row < lines.Length; row++)
            {
                for (int column = 0; column < lines[row].Length; column++)
                {
                    layout[row, column] = lines[row][column];
                }
            }
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}