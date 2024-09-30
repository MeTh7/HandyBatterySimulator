using System;
using System.Threading; // Simulate the battery loading more realistically

namespace HandyBatterySimulator
{
    class BatteryCharging
    {
        public static void StartCharging(ref int currentBattery)
        {
            int maxBattery = 100; // 100% battery

            Console.WriteLine("Battery is now charging...");

            // Simulates battery charging until it reaches 100%
            while (currentBattery <= maxBattery)
            {
                if (currentBattery % 5 == 0)
                {
                    // Shows the current battery percentage every 5%
                    Console.WriteLine($"Battery is loading... {currentBattery}%");
                }

                currentBattery++; // Increases the battery by 1%

                // Simulates a small delay in charging the battery
                Thread.Sleep(200); // Simulates a battery charging delay of 200 milliseconds
            }

            Console.WriteLine($"Battery is fully charged!");
            Console.ReadKey(); // Prevents the program from closing immediately
        }
    }
}