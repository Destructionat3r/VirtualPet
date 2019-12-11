using System;
using System.IO;

namespace VirtualPet
{
    public class Layout : IRealTimeComponent
    {
        public int displayMenu = 1;
        public string choice = "Menu";
        char[,] layout = new char[25, 78];
        string[] lines = File.ReadAllLines("Layout.txt");

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
            
            Console.SetCursorPosition(54, 2);
            Console.WriteLine(choice.PadRight(20));

            switch (displayMenu)
            {
                case 1:
                    for (int i = 4; i <= 18; i++)
                    {
                        Console.SetCursorPosition(54, i);

                        menu = i switch
                        {
                            4 => "1 - Shop",
                            5 => "2 - Inventory",
                            6 => "Esc - Back",
                            15 => "Up - Increase Temp",
                            16 => "Down - Decrease Temp",
                            _ => " ",
                        };
                        Console.WriteLine(menu.PadRight(20));
                    }
                    break;
                case 2:
                    for (int i = 4; i <= 18; i++)
                    {
                        Console.SetCursorPosition(54, i);

                        menu = i switch
                        {
                            4 => "1 - Food",
                            5 => "2 - Medicine",
                            6 => "3 - Toys",
                            7 => "Esc - Back",
                            _ => " ",
                        };
                        Console.WriteLine(menu.PadRight(20));
                    }
                    break;
                case 3:
                    Console.SetCursorPosition(62, 2);
                    Console.WriteLine("");

                    for (int i = 4; i <= 18; i++)
                    {
                        Console.SetCursorPosition(54, i);

                        menu = i switch
                        {
                            4 => "1 - Food",
                            5 => "2 - Medicine",
                            6 => "3 - Toys",
                            7 => "Esc - Back",
                            _ => " ",
                        };
                        menu = menu.PadRight(17);
                        Console.WriteLine(menu);
                    }
                    break;
            }            

            Console.SetCursorPosition(5, 18);
            Console.WriteLine("Health:");

            Console.SetCursorPosition(29, 18);
            Console.WriteLine("Mood:");

            Console.SetCursorPosition(5, 20);
            Console.WriteLine("Hunger:");

            Console.SetCursorPosition(29, 20);
            Console.WriteLine("Gold:");

            Console.SetCursorPosition(5, 22);
            Console.WriteLine("Current Temp:");

            Console.SetCursorPosition(29, 22);
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