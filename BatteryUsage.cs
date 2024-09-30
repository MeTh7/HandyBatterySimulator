using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyBatterySimulator
{
    class BatteryUsage
    {
        static void Main(string[] args)
        {
            int currentBattery = 100; // 100% battery
            int minBattery = 0; // 0% battery

            Console.WriteLine("Battery in use...");

            // Simulates battery usage until it reaches 20%
            while (currentBattery >= 20)
            {
                if (currentBattery % 5 == 0)
                {
                    Console.WriteLine($"Battery is in use... {currentBattery}%");
                }

                currentBattery--; // Decrease the battery by 1%
                Thread.Sleep(200); // Simulation of 200 milliseconds usage delay
            }

            // Shows a warning message when the battery reaches 20%
            if (currentBattery <= 20)
            {
                Console.WriteLine("Battery is running low!");
                Console.WriteLine("Would you like to change into battery saving mode? (Y/N)");

                string input = Console.ReadLine();

                if(input == "Y" || input == "y")
                {
                    Console.WriteLine("Battery saving mode is activated!");
                    // Battery charge decreases more slowly
                    while (currentBattery >= minBattery)
                    {
                        if (currentBattery % 5 == 0)
                        {
                            Console.WriteLine($"Battery is in use... {currentBattery}%");
                        }

                        currentBattery--; // Decrease the battery by 1%
                        Thread.Sleep(400); // Simulation of 400 milliseconds usage delay

                        // If battery reaches 5%, start charging
                        if (currentBattery == 5)
                        {
                            Console.WriteLine("Battery critically low! Starting charging...");
                            BatteryCharging.StartCharging(ref currentBattery); // Calls the StartCharging method
                            break; // Exits the loop
                        }
                    }
                }
                else if(input == "N" || input == "n")
                {
                    Console.WriteLine("Battery is running low! Please charge your device.");
                    // Battery usage continues until the battery is completely empty
                    while (currentBattery >= minBattery)
                    {
                        if (currentBattery % 5 == 0)
                        {
                            Console.WriteLine($"Battery is in use... {currentBattery}%");
                        }

                        currentBattery--; // Decrease the battery by 1%
                        Thread.Sleep(200); // Simulation of 200 milliseconds usage delay

                        // If battery reaches 5%, start charging
                        if (currentBattery == 5)
                        {
                            Console.WriteLine("Battery critically low! Starting charging...");
                            BatteryCharging.StartCharging(ref currentBattery); // Calls the StartCharging method
                            break; // Exits the loop
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                    // Shows the warning message again
                    Main(args); //Restarts the program or asks again
                }
            }
        }

    }
}
