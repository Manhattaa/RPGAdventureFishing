using System;
using System.Collections.Generic;
using System.Linq;

namespace RPGAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            int experience = 0;
            List<string> inventory = new List<string>();
            List<string> bank = new List<string>();

            FishingSkill fishingSkill = new FishingSkill();

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Train Fishing");
                Console.WriteLine("2. Placeholder");
                Console.WriteLine("3. Placeholder");
                Console.WriteLine("4. Placeholder");
                Console.WriteLine("5. Placeholder");
                Console.WriteLine("6. Visit Bank");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("What do you want to Fish?");
                        Console.WriteLine("1. Net Fishing Spot (Lumbridge Swamp)");
                        Console.WriteLine("2. Bait Fishing Spot (Draynor Village)");
                        Console.WriteLine("3. Bait Fishing Spot (Lumbridge)");
                        Console.WriteLine("4. Lure Fishing Spot (Barbarian Village)");
                        Console.WriteLine("5. Harpoon Fishing Spot (Catherby)");
                        Console.WriteLine("6. Cage Fishing Spot (Karamja)");
                        Console.WriteLine("7. Harpoon Fishing Spot (Fishing Guild)");

                        int fishingSpotChoice = int.Parse(Console.ReadLine());

                        int fishingLevel = fishingSkill.CalculateFishingLevel(experience);
                        Console.WriteLine($"Your current fishing level is {fishingLevel}.");
                        Console.WriteLine($"You have a total of {experience} Fishing EXP.");

                        switch (fishingSpotChoice)
                        {
                            case 1:
                                if (fishingLevel >= 1 && fishingLevel <= 14)
                                {
                                    for (int i = 0; i < 28; i++)
                                    {
                                        // Check if a 50% chance to catch anchovies
                                        bool catchAnchovies = (fishingLevel >= 15) && (new Random().Next(0, 2) == 0);

                                        if (catchAnchovies)
                                        {
                                            inventory.Add("Anchovy");
                                            experience += 20;
                                            Console.WriteLine("You caught an Anchovy!");
                                        }
                                        else
                                        {
                                            inventory.Add("Shrimp");
                                            experience += 5;
                                            Console.WriteLine("You caught a Shrimp!");
                                        }
                                    }

                                    Console.WriteLine("You have run out of space.");
                                    Console.WriteLine("1. Bank your fish");
                                    Console.WriteLine("2. Drop your fish");

                                    int fishingChoice = int.Parse(Console.ReadLine());

                                    if (fishingChoice == 1)
                                    {
                                        BankFish(inventory, bank);
                                    }
                                    else if (fishingChoice == 2)
                                    {
                                        inventory.Clear();
                                    }
                                }
                                break;

                                // Add logic for other fishing spots here
                        }
                        break;

                    case 6:
                        ViewBank(bank);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }
            }
        }

        static void BankFish(List<string> inventory, List<string> bank)
        {
            if (inventory.Count > 0)
            {
                Console.WriteLine("Banking fish...");
                bank.AddRange(inventory);
                inventory.Clear();
                Console.WriteLine("Fish have been banked.");
            }
            else
            {
                Console.WriteLine("You have no fish to bank.");
            }
        }

        static void ViewBank(List<string> bank)
        {
            Console.WriteLine("Items in your bank:");
            foreach (var item in bank)
            {
                int count = bank.Count(i => i == item);
                Console.WriteLine($"{item}: {count}");
            }
        }
    }

    class FishingSkill
    {
        public int CalculateFishingLevel(int experience)
        {
            int[] expTable = new int[]
            {
                 // Experience requirements for each fishing level (divided by 10)
                0, 8, 17, 27, 38, 51, 65, 80, 96, 115, 135, 158, 183, 210, 241, 274, 311, 352, 397, 447,
                501, 562, 629, 702, 784, 874, 973, 1082, 1203, 1336, 1483, 1645, 1824, 2022, 2234, 2461,
                2704, 2962, 3230, 3524, 3840, 4184, 4552, 4940, 5351, 5781, 6235, 6714, 7212, 7737, 8295,
                8884, 9502, 10107, 10721, 11386, 12032, 12738, 13465, 14277, 15184, 16145, 17117, 18184,
                19344, 20552, 21848, 23168, 24533, 25984, 27519, 29088, 30809, 32661, 34636, 36704, 38841,
                41119, 43425, 44700, 49261, 54210, 58713, 64044, 69818, 76115, 82968, 90302, 98422, 107993,
                117314, 128149, 139169, 150973, 163343, 176449, 190921, 206926, 230179
            };

            for (int level = 1; level <= 99; level++)
            {
                if (experience < expTable[level])
                {
                    return level;
                }
            }

            return 99;
        }
    }
}