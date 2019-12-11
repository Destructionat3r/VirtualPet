using System;
using System.IO;

namespace VirtualPet
{
    public class Elephant : IRealTimeComponent
    {
        char[,] sprite = new char[5, 19];
        string[] lines = File.ReadAllLines("Elephant.txt");

        public int Health { get; set; }
        public int Mood { get; set; }
        public int Hunger { get; set; }
        public decimal AmbientTemp { get; set; }

        /*
        public Elephant(string health, string mood, string hunger, decimal ambientTemp)
        {

        }
        */

        public void Display()
        {
            int i = 7;

            for (int row = 0; row < sprite.GetLength(0); row++)
            {
                Console.SetCursorPosition(9, i);

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
            throw new NotImplementedException();
        }
    }
}