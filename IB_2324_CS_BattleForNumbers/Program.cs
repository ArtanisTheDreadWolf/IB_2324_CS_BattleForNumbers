using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IB_2324_CS_BattleForNumbers
{
    internal class Program
    {
        // start 0740 end 0756 - 16 mins
        // assuming all users follow instructions, no error correcting required
        static void Main(string[] args)
        {
            Run();

        }
        static void Run()
        {
            Random rnd = new Random(); // random number generator
            int[] nums = { }; // numbers
            int[] tempNum = { }; // temporary numbers
            Gameplay();
        }
        static void Gameplay()
        {
           
            string uInput = ""; // user input
            int iInput = 0; // integer input
            while (true)
            {
                Console.Write("Please enter how many contestants you would like to have (5-12) : ");
                uInput = Console.ReadLine();
                iInput = int.Parse(uInput);
                if (iInput >= 5 && iInput <= 12)
                    break;
            }
            DisplayContestants(initializationofarray(iInput, new int[iInput]));
            
        }
        static int[] initializationofarray(int iInput, int[] nums)
        {
            Random rnd = new Random();
            for (int x = 0; x < nums.Length; x++)
            {
                // i just added a 100 number limit to make it easier
                nums[x] = rnd.Next(100);
            }
            return nums;
        }
        static void DisplayContestants(int[]nums)
        {
            Console.Write("\nYour contestants! ");
            for (int x = 0; x < nums.Length; x++)
            {
                Console.Write($" {nums[x]}\t");
               
            }
            Console.WriteLine("\n");
            Battlefield6(nums, new int[] { });
        }
        static void Battlefield6(int[]nums, int[] tempNum)
        {
            int round = 0; // round counter
            int fight = 0; // fight counter
            while (nums.Length > 1)
            {
                // example, if the length of nums = 7, the length of tempNum must be 4
                if (nums.Length % 2 == 1)
                    tempNum = new int[(nums.Length / 2) + 1];
                else
                    tempNum = new int[(nums.Length / 2)];

                round++;

                for (int x = 0; x < tempNum.Length; x++)
                {
                    fight++;

                    if (x != nums.Length - 1 - x)
                    {
                        Console.Write($"Round {round} Fight {fight} - {nums[x]} vs {nums[nums.Length - 1 - x]} \nWinner : ");
                        if (nums[x] > nums[nums.Length - 1 - x])
                        {
                            tempNum[x] = nums[x];
                            Console.WriteLine($"{nums[x]}!!!");
                        }
                        else
                        {
                            tempNum[x] = nums[nums.Length - 1 - x];
                            Console.WriteLine($"{nums[nums.Length - 1 - x]}!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Round {round} Fight {fight} - {nums[x]} has no opponents, it moves on to the next round.");
                        tempNum[x] = nums[x];
                    }
                }

                nums = tempNum;
                Console.WriteLine();
               
            }
            WinnerMessage(nums);
        }
        static void WinnerMessage(int[]nums)
        {
            Console.WriteLine($"End of competition! The winner is {nums[0]}!!! Congratulations!");

        }

    }
    
}
