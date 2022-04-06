using System;

namespace Puzzles {
    class Program {
        static void Main(string[] args){
            Console.WriteLine("Hello World!");
            randomArray();
        }

        static void randomArray(){
            Random r = new Random();
            double randomNum = r.NextDouble();
            String coin;
            if(randomNum < 0.5){
                coin = "Heads";
            } else {
                coin = "Tails";
            }
            Console.Write(coin);
        }

        static void coinFlip(){

        }

        static void names(){
            
        }
    }
}