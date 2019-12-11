using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    class StatCounter : IRealTimeComponent
    {
        int startHealth;
        int startMood;
        int startHunger;
        int startGold = 0;
        public int CurrentHealth;
        public int CurrentMood;
        public int CurrentHunger;
        public int CurrentGold;
        public decimal AmbientTemp;
        public decimal CurrentTemp;
        public decimal TempControl;

        public StatCounter(int health, int mood, int hunger, decimal ambientTemp)
        {
            startHealth = health;
            startMood = mood;
            startHunger = hunger;
            AmbientTemp = ambientTemp;
        }

        public void Display()
        { 
            Console.SetCursorPosition(13, 18);
            Console.WriteLine($"{CurrentHealth} / {startHealth} ");
            Console.SetCursorPosition(35, 18);
            Console.WriteLine($"{CurrentMood} / {startMood} ");
            Console.SetCursorPosition(13, 20);
            Console.WriteLine($"{CurrentHunger} / {startHunger} ");
            Console.SetCursorPosition(35, 20);
            Console.WriteLine($"{CurrentGold} ");
            Console.SetCursorPosition(19, 22);
            Console.WriteLine($"{CurrentTemp}°C ");
            Console.SetCursorPosition(19, 23);
            if (CurrentTemp > (AmbientTemp - 1) && CurrentTemp < (AmbientTemp + 1))
                Console.WriteLine("        ");
            if (CurrentTemp <= (AmbientTemp - 1))
                Console.WriteLine("Too Cold");
            if (CurrentTemp >= (AmbientTemp + 1))
                Console.WriteLine("Too Hot");
            Console.SetCursorPosition(42, 22);
            Console.WriteLine($"{AmbientTemp}°C ");
        }

        public void Initialise()
        {
            CurrentHealth = startHealth;
            CurrentMood = startMood;
            CurrentHunger = startHunger;
            CurrentGold = startGold;
            CurrentTemp = (AmbientTemp + 0.5m);
            TempControl = 0.05m;
        }

        public void Update()
        {
            if (CurrentHealth > 0)
            {
                CurrentMood--;
                if (CurrentMood < 0)
                    CurrentMood = 0;
                CurrentHunger--;
                if (CurrentHunger < 0)
                    CurrentHunger = 0;
                CurrentGold++;
                //CurrentTemp += TempControl;
            }
            if (CurrentHunger > 10 && CurrentHunger <= 50)
            {
                CurrentHealth--;
            }
            if (CurrentHunger <= 10)
            {
                CurrentHealth -= 2;
            }
            if (CurrentTemp <= (AmbientTemp - 1) || CurrentTemp >= (AmbientTemp + 1))
            {
                CurrentHealth--;
            }
        }
    }
}