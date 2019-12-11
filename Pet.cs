using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public abstract class Pet
    {
        private readonly PetType petType;
        public int Health { get; set; }
        public int Mood { get; set; }
        public int Hunger { get; set; }
        public decimal AmbientTemp { get; set; }

        public Pet(PetType petType, int health, int mood, int hunger, decimal ambientTemp)
        {
            this.petType = petType;
            Health = health;
            Mood = mood;
            Hunger = hunger;
            AmbientTemp = ambientTemp;
        }
    }
}
