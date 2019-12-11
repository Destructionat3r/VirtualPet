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
        Elephant nelly = new Elephant(PetType.Elephant, 100, 100, 100, 19.30m);
        StatCounter stats = new StatCounter(100, 100, 100, 19.30m);
        Layout layout = new Layout();

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
            nelly.Initialise();
            stats.Initialise();
        }

        public void CheckKeyInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1)
                {
                    if (layout.displayMenu < 3)
                    { 
                        if (layout.displayMenu == 1)
                            layout.choice = "Shop";
                        layout.displayMenu++;
                    }
                }

                if (keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2)
                {
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

                if (keyPressed == ConsoleKey.R)
                {
                    //counter.Initialise();
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
            nelly.Update();
            stats.Update();
        }

        public void Display()
        {
            Console.SetCursorPosition(0, 0);
            layout.Display();
            nelly.Display();
            stats.Display();
        }
    }
}