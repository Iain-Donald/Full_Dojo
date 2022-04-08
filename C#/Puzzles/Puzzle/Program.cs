using System;

namespace Puzzles {
    class Program {
        static void Main(string[] args){
            Console.WriteLine("Random array: ");
            randomArray();
            Console.Write("\nTossing a coin!\n");
            coinFlip();
            names();
        }

        static void randomArray(){
            Random r = new Random();
            int[] nums = new int[10];
            int min = 26;
            int max = 5;
            int sum = 0;
            for(int i = 0; i < 10; i++){
                nums[i] = r.Next(5, 26);
                if(nums[i] < min) min = nums[i];
                if(nums[i] > max) max = nums[i];
                sum += nums[i];
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine("\nMin: " + min + ", Max: " + max + ", Sum: " + sum);
        }

        static void coinFlip(){
            Random r = new Random();
            double randomNum = r.NextDouble();
            String coin;
            if(randomNum < 0.5){
                coin = "Heads\n\n";
            } else {
                coin = "Tails\n\n";
            }
            Console.Write(coin);
        }

        static void names(){
            String[] names = new String[] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random r = new Random();
            int randomIndex;
            String tempName;

            Console.Write("Names:          ");
            for(int i = 0; i < names.Length; i++) Console.Write(names[i] + " ");
            Console.Write("\nShuffled names: ");

            for(int i = 0; i < names.Length; i++){
                randomIndex = r.Next(0, names.Length);
                tempName = names[i];
                names[i] = names[randomIndex];
                names[randomIndex] = tempName;
            }

            for(int i = 0; i < names.Length; i++) Console.Write(names[i] + " ");
            
            Console.Write("\nNames over 5 characters: ");
            for(int i = 0; i < names.Length; i++){
                if(names[i].Length > 5)Console.Write(names[i] + " ");
            }
        }
    }
}