using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VirtualPet
{

    public enum AppState
    {
        Running,
        Paused,
        Exiting
    }

    class Simulation : IRealTimeComponent
    {
        //private bool appRunning = true;
        AppState appState = AppState.Running;
        Dog dog = new Dog(PetType.Dog, 100, 100, 100, 19.30m);
        StatCounter stats = new StatCounter(100, 100, 100, 19.30m);
        Layout layout = new Layout();
        Shop shop = new Shop();
        Inventory inv = new Inventory();

        public Simulation()
        {

        }

        public void Run()
        {
            Initialise();

            do
            {
                CheckKeyInput();

                switch (appState)
                {
                    case AppState.Running:
                        Update();
                        Display();
                        break;
                    case AppState.Paused:
                        break;
                    default:
                        break;
                }
                Thread.Sleep(500);
            } while (appState != AppState.Exiting);
            Environment.Exit(0);
        }

        public void Initialise()
        {
            Console.CursorVisible = false;
            Console.Clear();
            layout.Initialise();
            dog.Initialise();
            stats.Initialise();
            shop.Initialise();
        }

        public void CheckKeyInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1)
                {
                    if (layout.displayMenu == 3)
                    {
                        if (layout.choice == "Shop")
                        {
                            if (layout.page == "Food")
                            {
                                inv.AddItem("Food", layout.pageNo, 0);
                            }
                            if (layout.page == "Medicine")
                            {
                                inv.AddItem("Medicine", layout.pageNo, 0);
                            }
                            if (layout.page == "Toys")
                            {
                                inv.AddItem("Toys", layout.pageNo, 0);
                            }
                        }
                        if (layout.choice == "Inventory")
                        {
                            if (layout.page == "Food")
                            {
                                inv.UseItem("Food", layout.pageNo, 0);
                            }
                            if (layout.page == "Medicine")
                            {
                                inv.UseItem("Medicine", layout.pageNo, 0);
                            }
                            if (layout.page == "Toys")
                            {
                                inv.UseItem("Toys", layout.pageNo, 0);
                            }
                        }
                    }
                    if (layout.displayMenu == 2)
                    {
                        layout.page = "Food";
                        layout.displayMenu++;
                    }
                    if (layout.displayMenu <= 2)
                    {
                        layout.displayMenu++;
                        if (layout.displayMenu == 2)
                            layout.choice = "Shop";
                    }
                }

                if (keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2)
                {
                    if (layout.displayMenu == 3)
                    {
                        if (layout.choice == "Shop")
                        {
                            if (layout.page == "Food")
                            {
                                inv.AddItem("Food", layout.pageNo, 1);
                            }
                            if (layout.page == "Medicine")
                            {
                                inv.AddItem("Medicine", layout.pageNo, 1);
                            }
                            if (layout.page == "Toys")
                            {
                                inv.AddItem("Toys", layout.pageNo, 1);
                            }
                        }
                        if (layout.choice == "Inventory")
                        {
                            if (layout.page == "Food")
                            {
                                inv.UseItem("Food", layout.pageNo, 1);
                            }
                            if (layout.page == "Medicine")
                            {
                                inv.UseItem("Medicine", layout.pageNo, 1);
                            }
                            if (layout.page == "Toys")
                            {
                                inv.UseItem("Toys", layout.pageNo, 1);
                            }
                        }
                    }
                    if (layout.displayMenu == 2)
                    {
                        layout.page = "Medicine";
                        layout.displayMenu++;
                    }
                    if (layout.displayMenu < 3)
                    {
                        if (layout.displayMenu == 1)
                            layout.choice = "Inventory";
                        layout.displayMenu++;
                    }
                }

                if (keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3)
                {
                    if (layout.displayMenu == 3)
                    {
                        if (layout.choice == "Shop")
                        {
                            if (layout.page == "Food")
                            {
                                inv.AddItem("Food", layout.pageNo, 2);
                            }
                            if (layout.page == "Medicine")
                            {
                                inv.AddItem("Medicine", layout.pageNo, 2);
                            }
                            if (layout.page == "Toys")
                            {
                                inv.AddItem("Toys", layout.pageNo, 2);
                            }
                        }
                        if (layout.choice == "Inventory")
                        {
                            if (layout.page == "Food")
                            {
                                inv.UseItem("Food", layout.pageNo, 2);
                            }
                            if (layout.page == "Medicine")
                            {
                                inv.UseItem("Medicine", layout.pageNo, 2);
                            }
                            if (layout.page == "Toys")
                            {
                                inv.UseItem("Toys", layout.pageNo, 2);
                            }
                        }
                    }
                    if (layout.displayMenu == 2)
                    {
                        layout.page = "Toys";
                        layout.displayMenu++;
                    }
                }

                if (keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4)
                {
                    if (layout.displayMenu == 3)
                    {
                        if (layout.choice == "Shop")
                        {
                            if (layout.page == "Food")
                            {
                                inv.AddItem("Food", layout.pageNo, 3);
                            }
                            if (layout.page == "Medicine")
                            {
                                inv.AddItem("Medicine", layout.pageNo, 3);
                            }
                            if (layout.page == "Toys")
                            {
                                inv.AddItem("Toys", layout.pageNo, 3);
                            }
                        }
                        if (layout.choice == "Inventory")
                        {
                            if (layout.page == "Food")
                            {
                                inv.UseItem("Food", layout.pageNo, 3);
                            }
                            if (layout.page == "Medicine")
                            {
                                inv.UseItem("Medicine", layout.pageNo, 3);
                            }
                            if (layout.page == "Toys")
                            {
                                inv.UseItem("Toys", layout.pageNo, 3);
                            }
                        }
                    }
                }

                if (keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5)
                {
                    if (layout.displayMenu == 3)
                    {
                        if (layout.choice == "Shop" && layout.page == "Food")
                        {
                            inv.AddItem("Food", layout.pageNo, 4);
                        }
                        if (layout.choice == "Inventory")
                        {
                            if (layout.page == "Food")
                            {
                                inv.UseItem("Food", layout.pageNo, 4);
                            }
                            if (layout.page == "Medicine")
                            {
                                inv.UseItem("Medicine", layout.pageNo, 4);
                            }
                            if (layout.page == "Toys")
                            {
                                inv.UseItem("Toys", layout.pageNo, 4);
                            }
                        }
                    }
                }

                if (keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6)
                {
                    if (layout.displayMenu == 3)
                    {
                        if (layout.choice == "Inventory" && layout.page == "Food")
                        {
                            inv.UseItem("Food", layout.pageNo, 5);
                        }
                    }
                }

                if (keyPressed == ConsoleKey.Escape)
                {
                    if (layout.displayMenu == 1)
                    {
                        appState = AppState.Exiting;
                    }
                    else
                    {
                        layout.displayMenu--;
                        if (layout.displayMenu == 2)
                            layout.pageNo = 1;
                        if (layout.displayMenu == 1)
                            layout.choice = "Menu";
                    }
                }

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    stats.TempControl += 0.05m;
                }

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    stats.TempControl -= 0.05m;
                }

                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    if (layout.displayMenu == 3 && layout.pageNo != 1)
                    {
                        layout.pageNo--;
                    }
                }

                if (keyPressed == ConsoleKey.RightArrow)
                {
                    if (layout.displayMenu == 3)
                    {
                        if (layout.choice == "Shop")
                        {
                            if (layout.page == "Food" && layout.pageNo < Shop.foodPages)
                            {
                                layout.pageNo++;
                            }
                            if (layout.page == "Medicine" && layout.pageNo < Shop.medicinePages)
                            {
                                layout.pageNo++;
                            }
                            if (layout.page == "Toys" && layout.pageNo < Shop.toyPages)
                            {
                                layout.pageNo++;
                            }
                        }
                        if (layout.choice == "Inventory")
                        {
                            if (layout.page == "Food" && layout.pageNo < Inventory.foodPages)
                            {
                                layout.pageNo++;
                            }
                            if (layout.page == "Medicine" && layout.pageNo < Inventory.medicinePages)
                            {
                                layout.pageNo++;
                            }
                            if (layout.page == "Toys" && layout.pageNo < Inventory.toyPages)
                            {
                                layout.pageNo++;
                            }
                        }
                    }
                }

                if (keyPressed == ConsoleKey.P)
                {
                    if (appState != AppState.Paused)
                    {
                        appState = AppState.Paused;
                        Console.SetCursorPosition(20, 11);
                        Console.WriteLine("PAUSED");
                    }
                    else if (appState == AppState.Paused)
                    {
                        appState = AppState.Running;
                        Console.SetCursorPosition(20, 11);
                        Console.WriteLine("      ");
                    }

                }
            }
        }

        public void Update()
        {
            stats.Update();
            inv.Update();
            shop.Update();
        }

        public void Display()
        {
            Console.SetCursorPosition(0, 0);
            layout.Display();
            dog.Display();
            stats.Display();
        }
    }
}