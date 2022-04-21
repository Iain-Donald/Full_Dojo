using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[9];
            for(int i = 0; i <= nums.Length - 1; i++){
                nums[i] = i + 1;
                Console.WriteLine(nums[i]);
            }

            string[] names = new string[] {"Tim", "Martin", "Nikki", "Sara"};

            bool[] TF = new bool[10];
            for(int i = 0; i <= TF.Length - 1; i++){
                if(i % 2 == 0) TF[i] = true;
                else TF[i] = false;
                Console.WriteLine(TF[i]);
            }

            string[] flavors = new string[] {"Vanilla", "Chocolate", "Mint", "Cookie Dough", "Strawberry"};
            Console.WriteLine("Flavors length: " + flavors.Length);
            Console.WriteLine("Flavor 3: " + flavors[2]);
            string[] newFlavors = new string[flavors.Length - 1];
            for(int i = 0; i < flavors.Length - 1; i++){
                if(i < 3){
                    newFlavors[i] = flavors[i];
                } else {
                    newFlavors[i] = flavors[i + 1];
                }
            }
            Console.WriteLine("Flavor length: " + newFlavors.Length);

            Dictionary<string, string> nameAndFlavor =
                new Dictionary<string, string>();
            Random r = new Random();
            for(int i = 0; i < names.Length; i++){
                int rInt = r.Next(0, flavors.Length);
                nameAndFlavor.Add(names[i], flavors[rInt]);
            }
            foreach (string key in nameAndFlavor.Keys){
                Console.Write("Name: " + key + ", Flavor: " + nameAndFlavor[key] + "\n");
            }
        }
    }
}
