using System;
using System.IO;

namespace VirtualPet
{
    public class Layout : IRealTimeComponent
    {
        public int displayMenu = 1;
        char[,] layout = new char[23, 66];
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

            
            switch (displayMenu)
            {
                case 1:
                    Console.SetCursorPosition(52, 2);
                    Console.WriteLine("Menu");

                    for (int i = 4; i <= 6; i++)
                    {
                        Console.SetCursorPosition(47, i);

                        switch (i)
                        {
                            case 4:
                                menu = "1 - Shop";
                                break;
                            case 5:
                                menu = "2 - Inventory";
                                break;
                            case 6:
                                menu = "H - Help";
                                break;
                        }

                        Console.WriteLine(menu);
                    }
                    break;
            }            

            Console.SetCursorPosition(5, 18);
            Console.WriteLine("Health: ");

            Console.SetCursorPosition(20, 18);
            Console.WriteLine("Mood: ");
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