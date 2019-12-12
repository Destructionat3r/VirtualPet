using System;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation sim = new Simulation();

            Console.SetWindowSize(79, 29);
            sim.Run();
        }
    }
}
