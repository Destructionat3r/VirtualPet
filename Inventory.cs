using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    class Inventory
    {
        public static List<Food> invFood = new List<Food>();
        public static List<Medicine> invMedicine = new List<Medicine>();
        public static List<Toys> invToys = new List<Toys>();
        public static int foodPages;
        public static int medicinePages;
        public static int toyPages;
        StatCounter stats = new StatCounter();
        static bool purchased = true;

        public void Display(string page, int pageNo)
        {
            int number = 1;
            int counter = 4;
            int index;
            if (page == "Food")
            {
                index = (pageNo - 1) * 6;
                for (int i = 0; i < 6; i++)
                {
                    if (index < invFood.Count)
                    {
                        invFood[index].Display(number, counter, false);
                        index++;
                        number++;
                        counter += 3;
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
                index = (pageNo - 1) * 4;
                for (int i = 0; i < 4; i++)
                {
                    if (index < invMedicine.Count)
                    {
                        invMedicine[index].Display(number, counter, false);
                        index++;
                        number++;
                        counter += 5;
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
                index = (pageNo - 1) * 5;
                for (int i = 0; i < 5; i++)
                {
                    if (index < invToys.Count)
                    {
                        invToys[index].Display(number, counter, false);
                        index++;
                        number++;
                        counter += 4;
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

        public void AddItem(string page, int pageNo, int itemNo)
        {
            int index;
            if (page == "Food")
            {
                index = (pageNo - 1) * 5 + itemNo;
                purchased = stats.BuyItem(Shop.shopFood[index].Price, purchased);
                if (purchased == true)
                    invFood.Add(new Food(Shop.shopFood[index].Name, Shop.shopFood[index].HungerIncrease, Shop.shopFood[index].Price));
            }
            if (page == "Medicine")
            {
                index = (pageNo - 1) * 4 + itemNo;
                purchased = stats.BuyItem(Shop.shopMedicine[index].Price, purchased);
                if (purchased == true)
                    invMedicine.Add(new Medicine(Shop.shopMedicine[index].Name, Shop.shopMedicine[index].Uses, Shop.shopMedicine[index].HealthIncrease, Shop.shopMedicine[index].HungerDecrease, Shop.shopMedicine[index].Price));
            }
            if (page == "Toys")
            {
                index = (pageNo - 1) * 4 + itemNo;
                purchased = stats.BuyItem(Shop.shopToys[itemNo].Price, purchased);
                if (purchased == true)
                    invToys.Add(new Toys(Shop.shopToys[index].Name, Shop.shopToys[index].Uses, Shop.shopToys[index].MoodIncrease, Shop.shopToys[index].Price));
            }
        }

        public void UseItem(string page, int pageNo, int indexHelp)
        {
            if (page == "Food")
            {
                int index = (pageNo - 1) * 6 + indexHelp;
                if (index < invFood.Count)
                {
                    stats.EatFood(invFood[index].HungerIncrease);
                    invFood.RemoveAt(index);
                }
            }
            if (page == "Medicine")
            {
                int index = (pageNo - 1) * 4 + indexHelp;
                if (index < invMedicine.Count)
                {
                    stats.UseMedicine(invMedicine[index].HealthIncrease, invMedicine[index].HungerDecrease);
                    invMedicine[index].Uses--;
                    if (invMedicine[index].Uses == 0)
                    {
                        invMedicine.RemoveAt(index);
                    }
                }
            }
            if (page == "Toys")
            {
                int index = (pageNo - 1) * 5 + indexHelp;
                if (index < invToys.Count)
                {
                    stats.PlayWithToy(invToys[index].MoodIncrease);
                    invToys[index].Uses--;
                    if (invToys[index].Uses == 0)
                    {
                        invToys.RemoveAt(index);
                    }
                }
            }
        }

        public void Update()
        {
            foodPages = stats.UpdateFoodPages(foodPages, invFood.Count, 6);
            medicinePages = stats.UpdateMedicinePages(medicinePages, invMedicine.Count, 4);
            toyPages = stats.UpdateToysPages(toyPages, invToys.Count, 5);
        }
    }
}
