using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class Menu
    {
        public void DisplayMenu()
        {
            Console.WriteLine(@"
                        (1) Add a new vehicle to the garage
                        (2) Display info of vehicles in the garage
                        (3) Change status for a vehicle
                        (4) Inflate wheels of a vehicle
                        (5) Fill gas for a vehicle
                        (6) Charge the battery for an electric vehicle
                        (7) Display full info of a vehicle
                        (8) Exit");
        }
        private bool isValidMenuChoice(char i_userInput)
        {
            int userChoice;
            userChoice = int.Parse(i_userInput.ToString());
            return (userChoice < 9 && userChoice > 0);
        }
        public int MenuOptions(out bool io_quitFlag)
        {
            char userInput;
            int userChoice;
            Console.WriteLine("Welcome to our Garage! Please select an option from the following:");
            DisplayMenu();
            userInput = Console.ReadKey().KeyChar;
            while (!isValidMenuChoice(userInput))
            {
                Console.Clear();
                Console.WriteLine("Please select again from the following options:");
                DisplayMenu();
                userInput = Console.ReadLine()[0];
            }

            userChoice = int.Parse(userInput.ToString());
            if (userChoice == 8)
            {
                io_quitFlag = true;
            }

            else io_quitFlag = false;

            return userChoice;
        }
    }
}
