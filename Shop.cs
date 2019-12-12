using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    class Shop
    {
        public static List<Food> shopFood = new List<Food>();
        public static List<Medicine> shopMedicine = new List<Medicine>();
        public static List<Toys> shopToys = new List<Toys>();
        public static int foodPages;
        public static int medicinePages;
        public static int toyPages;
        StatCounter stats = new StatCounter();

        public void Display(string page, int pageNo)
        {
            int number = 1;
            int counter = 4;
            int index;
            if (page == "Food")
            {
                index = (pageNo - 1) * 5;
                for (int i = 0; i < 5; i++)
                {
                    if (index < shopFood.Count)
                    {
                        shopFood[index].Display(number, counter, true);
                        index++;
                        number++;
                        counter += 4;
                    }
                }
                Console.SetCursorPosition(53, 24);
                if (foodPages > 1)
                {
                    if (pageNo == 1)
                        Console.WriteLine($"     Page {pageNo} of {foodPages}    ->");
                    if (pageNo < foodPages && pageNo > 1)
                        Console.WriteLine($"<-   Page {pageNo} of {foodPages}    ->");
                    if (pageNo == foodPages)
                        Console.WriteLine($"<-   Page {pageNo} of {foodPages}      ");
                }
                else
                {
                    Console.WriteLine($"     Page {pageNo} of {foodPages}      ");
                }
            }
            if (page == "Medicine")
            {
                index = (pageNo - 1) * 3;
                for (int i = 0; i < 3; i++)
                {
                    if (index < shopMedicine.Count)
                    {
                        shopMedicine[index].Display(number, counter, true);
                        index++;
                        number++;
                        counter += 6;
                    }
                }
                Console.SetCursorPosition(53, 24);
                if (medicinePages > 1)
                {
                    if (pageNo == 1)
                        Console.WriteLine($"     Page {pageNo} of {medicinePages}    ->");
                    if (pageNo < medicinePages && pageNo > 1)
                        Console.WriteLine($"<-   Page {pageNo} of {medicinePages}    ->");
                    if (pageNo == medicinePages)
                        Console.WriteLine($"<-   Page {pageNo} of {medicinePages}      ");
                }
                else
                {
                    Console.WriteLine($"     Page {pageNo} of {medicinePages}      ");
                }
            }
            if (page == "Toys")
            {
                index = (pageNo - 1) * 4;
                for (int i = 0; i < 4; i++)
                {
                    if (index < shopToys.Count)
                    {
                        shopToys[index].Display(number, counter, true);
                        index++;
                        number++;
                        counter += 5;
                    }
                }
                Console.SetCursorPosition(53, 24);
                if (toyPages > 1)
                {
                    if (pageNo == 1)
                        Console.WriteLine($"     Page {pageNo} of {toyPages}    ->");
                    if (pageNo < toyPages && pageNo > 1)
                        Console.WriteLine($"<-   Page {pageNo} of {toyPages}    ->");
                    if (pageNo == toyPages)
                        Console.WriteLine($"<-   Page {pageNo} of {toyPages}      ");
                }
                else
                {
                    Console.WriteLine($"     Page {pageNo} of {toyPages}      ");
                }
            }
        }

        public void Initialise()
        { 
            using (StreamReader sr = new StreamReader("Food.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    shopFood.Add(new Food(parts[0], Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2])));
                }
            }

            using (StreamReader sr = new StreamReader("Medicine.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    shopMedicine.Add(new Medicine(parts[0], Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]), Convert.ToInt32(parts[4])));
                }
            }

            using (StreamReader sr = new StreamReader("Toys.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    shopToys.Add(new Toys(parts[0], Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3])));
                }
            }
        }

        public void Update()
        {
            foodPages = stats.UpdateFoodPages(foodPages, shopFood.Count, 5);
            medicinePages = stats.UpdateMedicinePages(medicinePages, shopMedicine.Count, 3);
            toyPages = stats.UpdateToysPages(toyPages, shopToys.Count, 4);
        }
    }
}
