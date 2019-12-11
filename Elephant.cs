using System;
using System.IO;

namespace VirtualPet
{
    public class Elephant : IRealTimeComponent
    {
        char[,] sprite = new char[5, 20];
        string[] lines = File.ReadAllLines("Elephant.txt");

        private int MaxHealth { get; set; }
        private int MaxMood { get; set; }
        private int MaxHunger { get; set; }
        public decimal AmbientTemp { get; set; }

        
        public Elephant(PetType petType, int health, int mood, int hunger, decimal ambientTemp)
        {
            MaxHealth = health;
            MaxMood = mood;
            MaxHunger = hunger;
            AmbientTemp = ambientTemp;
        }

        public void Display()
        {
            int i = 5;

            for (int row = 0; row < sprite.GetLength(0); row++)
            {
                Console.SetCursorPosition(15, i);

                for (int column = 0; column < sprite.GetLength(1); column++)
                {
                    Console.Write(sprite[row, column]);
                }
                i++;
            }
        }

        public void Initialise()
        {
            for (int row = 0; row < lines.Length; row++)
            {
                for (int column = 0; column < lines[row].Length; column++)
                {
                    sprite[row, column] = lines[row][column];
                }
            }
        }

        public void Update()
        {

        }
    }
}