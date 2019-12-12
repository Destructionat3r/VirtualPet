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
        public static int CurrentHealth;
        public static int CurrentMood;
        public static int CurrentHunger;
        public static int MaxHealth;
        public static int MaxMood;
        public static int MaxHunger;
        public static int CurrentGold;
        public decimal AmbientTemp;
        public decimal CurrentTemp;
        public decimal TempControl;
        AppState appState = AppState.Running;

        public StatCounter()
        {

        }

        public StatCounter(int health, int mood, int hunger, decimal ambientTemp)
        {
            startHealth = health;
            startMood = mood;
            startHunger = hunger;
            AmbientTemp = ambientTemp;
        }

        public void Display()
        { 
            Console.SetCursorPosition(11, 21);
            Console.WriteLine($"{CurrentHealth} / {startHealth} ");
            Console.SetCursorPosition(35, 21);
            Console.WriteLine($"{CurrentMood} / {startMood} ");
            Console.SetCursorPosition(11, 23);
            Console.WriteLine($"{CurrentHunger} / {startHunger} ");
            Console.SetCursorPosition(35, 23);
            Console.WriteLine($"{CurrentGold} ");
            Console.SetCursorPosition(17, 25);
            Console.WriteLine($"{CurrentTemp}°C ");
            Console.SetCursorPosition(17, 26);
            if (CurrentTemp > (AmbientTemp - 1) && CurrentTemp < (AmbientTemp + 1))
                Console.WriteLine("        ");
            if (CurrentTemp <= (AmbientTemp - 1))
                Console.WriteLine("Too Cold");
            if (CurrentTemp >= (AmbientTemp + 1))
                Console.WriteLine("Too Hot");
            Console.SetCursorPosition(42, 25);
            Console.WriteLine($"{AmbientTemp}°C ");
        }

        public void Initialise()
        {
            CurrentHealth = 10;
            MaxHealth = 10;
            CurrentMood = startMood;
            MaxMood = startMood;
            CurrentHunger = startHunger;
            MaxHunger = startHunger;
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
                CurrentTemp += TempControl;
            }
            if (CurrentHunger > 10 && CurrentHunger <= 50)
            {
                CurrentHealth--;
            }
            if (CurrentHunger <= 10)
            {
                CurrentHealth -= 2;
                if (CurrentHealth < 0)
                    CurrentHealth = 0;
                if (CurrentHealth == 0)
                {
                    appState = AppState.Paused;
                }
            }
            if (CurrentTemp <= (AmbientTemp - 1) || CurrentTemp >= (AmbientTemp + 1))
            {
                CurrentHealth--;
            }
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }

        public bool BuyItem(int price, bool purchased)
        {
            if (CurrentGold >= price)
            {
                CurrentGold -= price;
                purchased = true;
            }

            return purchased;
        }

        public void EatFood(int hungerGain)
        {
            CurrentHunger += hungerGain;
            if (CurrentHunger > MaxHunger)
                CurrentHunger = MaxHunger;
        }

        public void UseMedicine(int healthGain)
        {
            CurrentHealth += healthGain;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }

        public void PlayWithToy(int moodGain)
        {
            CurrentMood += moodGain;
            if (CurrentMood > MaxMood)
                CurrentMood = MaxMood;
        }

        public int UpdateFoodPages(int pages, double foodListCount, double amountPerPage)
        {
            pages = (int)Math.Ceiling((double)foodListCount / (double)amountPerPage);
            if (pages == 0)
                pages = 1;
            return pages;
        }

        public int UpdateMedicinePages(int pages, double medicineListCount, double amountPerPage)
        {
            pages = (int)Math.Ceiling((double)medicineListCount / (double)amountPerPage);
            if (pages == 0)
                pages = 1;
            return pages;
        }

        public int UpdateToysPages(int pages, double toysListCount, double amountPerPage)
        {
            pages = (int)Math.Ceiling((double)toysListCount / (double)amountPerPage);
            if (pages == 0)
                pages = 1;
            return pages;
        }
    }
}