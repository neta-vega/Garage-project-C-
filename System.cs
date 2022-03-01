using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    class System
    {

        Garage m_MyGarage = new Garage();
        public void RunSystem()
        {
            int userChoice;
            Menu menu = new Menu();
            string liscencePlateNum;
            bool quitFlag = false;

            while (!quitFlag)
            {
                userChoice = menu.MenuOptions(out quitFlag);
                Console.Clear();
                if (quitFlag) break;


                if (userChoice == 1)
                {
                    liscencePlateNum = getLiscencePlateNumber();
                    AddVehicle(liscencePlateNum);
                }

                if (userChoice == 2)
                {
                    DisplayPlateNumbers(displayMode());
                }

                if (userChoice == 3)
                {
                    liscencePlateNum = findByLiscencePlateNumber();
                    ChangeStatus(liscencePlateNum);
                }

                if (userChoice == 4)
                {
                    liscencePlateNum = findByLiscencePlateNumber();
                    InflateWheelsToMax(liscencePlateNum);
                }

                if (userChoice == 5)
                {
                    liscencePlateNum = findByLiscencePlateNumber();
                    FuelVehicle(liscencePlateNum);
                }

                if (userChoice == 6)
                {
                    liscencePlateNum = findByLiscencePlateNumber();
                    ChargeElectricCar(liscencePlateNum);
                }

                if (userChoice == 7)
                {
                    liscencePlateNum = findByLiscencePlateNumber();
                    DisplayVehicleInfo(liscencePlateNum);
                }

                Console.Clear();
            }
        }
        private void returnToMenu()
        {
            char getCharacter;
            Console.WriteLine("Press any key to return to menu");
            getCharacter = Console.ReadKey().KeyChar;
        }
        public Vehicle.eVehicleType GetVehicleTypeOptionFromUser()
        {
            string userInput;
            int userChoice = 0;
            Vehicle.eVehicleType vehicleType;
            bool isUserInputValid = false;
            bool isInt = false;

            Console.WriteLine("Please select the type of your vehicle: (1) car  (2) motorcycle  (3) truck");
            userInput = Console.ReadLine();
            while (!isUserInputValid)
            {
                try
                {
                    isInt = int.TryParse(userInput, out userChoice);
                    if (!isInt)
                    {

                        throw new FormatException("Please select an option from above: ");
                    }

                    if (userChoice < 1 || userChoice > 3)
                    {
                        throw new ValueOutOfRangeException(1, 3, String.Format("Try again,"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }

                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            vehicleType = (Vehicle.eVehicleType)userChoice;
            return vehicleType;
        }
        public Vehicle.eEnergyType GetEngineTypeOptionFromUser()
        {
            string userInput;
            int userChoice = 0;
            Vehicle.eEnergyType EngineType;
            bool isUserInputValid = false;
            bool isInt = false;

            Console.WriteLine("Please select the type of your vehicle's engine: (1) Fuel  (2) Electric");
            userInput = Console.ReadLine();
            while (!isUserInputValid || !isInt)
            {
                try
                {
                    isInt = int.TryParse(userInput, out userChoice);
                    if (!isInt)
                    {
                        throw new FormatException("Please select an option from above:");
                    }
                    if (userChoice < 1 || userChoice > 2)
                    {
                        throw new ValueOutOfRangeException(1, 2, String.Format("Please select again from the options above:"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }

                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            EngineType = (Vehicle.eEnergyType)userChoice;
            return EngineType;
        }

        private string getLiscencePlateNumber()
        {
            string liscencePlate;

            Console.WriteLine("Please enter liscence plate number (8 characters long):");
            liscencePlate = Console.ReadLine();
            while (liscencePlate.Length != 8 || !StringValidation.ContainsOnlyLettersAndNumbers(liscencePlate))
            {
                Console.WriteLine("License can only contain letters and numbers.");
                liscencePlate = Console.ReadLine();
            }

            return liscencePlate;
        }
        private string findByLiscencePlateNumber()
        {
            string liscencePlate;

            Console.WriteLine("Please enter liscence plate number:");
            liscencePlate = Console.ReadLine();
            while (!Garage.vehiclesInTheGarage.ContainsKey(liscencePlate))
            {
                Console.WriteLine("Vehicle not found, please try again");
                liscencePlate = Console.ReadLine();
            }

            return liscencePlate;
        }
        private float getInitialAmountOfGas()
        {
            string userInput;
            float amountOfGas;

            Console.WriteLine("how much gas does your vehicle conatins currently?: ");
            userInput = Console.ReadLine();
            while (!float.TryParse(userInput, out amountOfGas))
            {
                Console.WriteLine("Please type the number of litters to fill:");
                userInput = Console.ReadLine();
            }

            return amountOfGas;
        }
        private float getCurrChargeInHours()
        {
            string userInput;
            float currChargeInHours = 0;
            bool isFloat = false;

            Console.WriteLine("How much time the vehicle was charged? ");
            userInput = Console.ReadLine();
            while (!isFloat)
            {
                try
                {
                    isFloat = float.TryParse(userInput, out currChargeInHours);
                    if (!isFloat)
                    {
                        throw new FormatException("How much time the vehicle was charged? (numbers only)");
                    }

                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                if (!isFloat)
                {
                    userInput = Console.ReadLine();
                }
            }

            return currChargeInHours;
        }
        public void AddVehicle(string i_liscencePlateNumber)
        {
            Vehicle checkIfNewVehicle;

            if (Garage.vehiclesInTheGarage.ContainsKey(i_liscencePlateNumber))
            {
                Garage.vehiclesInTheGarage.TryGetValue(i_liscencePlateNumber, out checkIfNewVehicle);
                checkIfNewVehicle.VehicleStatus = Garage.eVehicleStatus.onGoing;
                Console.WriteLine("Vehicle already exists, vehicle's status changed to OnGoing!");
            }
            else
            {
                Vehicle.eVehicleType vehicleType;
                vehicleType = GetVehicleTypeOptionFromUser();
                if (vehicleType == Vehicle.eVehicleType.Car)
                {
                    CreateCar(i_liscencePlateNumber, out checkIfNewVehicle);
                }

                else if (vehicleType == Vehicle.eVehicleType.Motorcycle)
                {
                    CreateMotorcycle(i_liscencePlateNumber, out checkIfNewVehicle);
                }

                else// vehicle type is truck
                {
                    CreateTruck(i_liscencePlateNumber, out checkIfNewVehicle);
                }
                Garage.vehiclesInTheGarage.Add(i_liscencePlateNumber, checkIfNewVehicle);
                Console.WriteLine("Vehicle added successfully!");
            }

            returnToMenu();
        }
        public void CreateCar(string i_liscencePlateNumber, out Vehicle io_newVehicle)
        {
            Vehicle.eEnergyType engineType;
            EnergySystem energySystem;
            string modelName = GetModelName();
            engineType = GetEngineTypeOptionFromUser();
            int numOfDoors = getNumOfDoors();
            Car.eColor color = getCarColor();
            float currentAirPressure = GetCurrentAirPressure();
            string wheelsMakerName = GetWheelsMakerName();
            float currChargeTimeInHours = 0;

            if (engineType == Vehicle.eEnergyType.Electric)
            {
                currChargeTimeInHours = getCurrChargeInHours();
                if (currChargeTimeInHours > 3.2f)
                {
                    currChargeTimeInHours = 3.2f;
                }

                energySystem = new ElectricSystem(currChargeTimeInHours, 3.2f);
            }

            else //engineType is fuel
            {
                energySystem = new FuelSystem(FuelSystem.eFuelType.Octan95, 45.0f, getInitialAmountOfGas());
            }

            io_newVehicle = new Car(energySystem, numOfDoors, color, modelName,
                i_liscencePlateNumber, currentAirPressure, wheelsMakerName, Vehicle.eVehicleType.Car);
        }
        private Car.eColor getCarColor()
        {
            string userInput;
            int colorChoice = 0;
            bool isUserInputValid = false;
            bool isInt = false;

            Console.WriteLine("Please choose your car's color: (1) Red  (2) Silver  (3) White  (4) Black");
            userInput = Console.ReadLine();

            while (!isUserInputValid || !isInt)
            {
                try
                {
                    isInt = int.TryParse(userInput, out colorChoice);
                    if (!isInt)
                    {
                        throw new FormatException("Please select from the options above:");
                    }
                    if (colorChoice < 1 || colorChoice > 4)
                    {
                        throw new ValueOutOfRangeException(1, 4, String.Format("Try again,:"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }

                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            return (Car.eColor)colorChoice;
        }
        private int getNumOfDoors()
        {
            string userInput;
            int numOfDoors = 0;
            bool isUserInputValid = false;
            bool isInt = false;

            Console.WriteLine("Please choose the number of doors in your car: 2/3/4/5");
            userInput = Console.ReadLine();

            while (!isUserInputValid || !isInt)
            {
                try
                {
                    isInt = int.TryParse(userInput, out numOfDoors);
                    if (!isInt)
                    {
                        throw new FormatException("Please select again from the options above:");
                    }
                    if (numOfDoors < 2 || numOfDoors > 5)
                    {
                        throw new ValueOutOfRangeException(2, 5, String.Format("Try again, "));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }

                catch(FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }

                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            return numOfDoors;
        }
        public void CreateMotorcycle(string i_liscencePlateNumber, out Vehicle io_newVehicle)
        {
            Vehicle.eEnergyType engineType;
            string modelName = GetModelName();
            engineType = GetEngineTypeOptionFromUser();
            MotorCycle.eLisenceType liscenceType = GetLiscenceTypeFromUser();
            int engineVolume = GetEngineVolumeFromUser();
            float currentAirPressure = GetCurrentAirPressure();
            string wheelsMakerName = GetWheelsMakerName();
            EnergySystem energySystem;

            if (engineType == Vehicle.eEnergyType.Electric)
            {
                energySystem = new ElectricSystem(getCurrChargeInHours(), 1.8f);
            }

            else // engine type is fuel
            {
                energySystem = new FuelSystem(FuelSystem.eFuelType.Octan98, 6.0f, getInitialAmountOfGas());
            }
            io_newVehicle = new MotorCycle(energySystem, liscenceType, engineVolume, modelName,
                i_liscencePlateNumber, currentAirPressure, wheelsMakerName, Vehicle.eVehicleType.Motorcycle);
        }
        public int GetEngineVolumeFromUser()
        {
            string userInput;
            int engineVolume = 0;

            Console.WriteLine("Please insert engine volume in CC: ");
            userInput = Console.ReadLine();
            while (!int.TryParse(userInput, out engineVolume))
            {
                Console.WriteLine("Please insert a number ");
                userInput = Console.ReadLine();
            }

            return engineVolume;
        }
        public MotorCycle.eLisenceType GetLiscenceTypeFromUser()
        {
            string userInput;
            int liscenceTypeChoice = 0;
            bool isUserInputValid = false;
            bool isInt = false;

            Console.WriteLine("Please select liscence type: (1) AA (2) BB (3) B1  (4) A");
            userInput = Console.ReadLine();
            while (!isUserInputValid || !isInt)
            {
                try
                {
                    isInt = int.TryParse(userInput, out liscenceTypeChoice);
                    if(!isInt)
                    {
                        throw new FormatException("Please select again from the options above:");
                    }
                    if (liscenceTypeChoice < 1 || liscenceTypeChoice > 4)
                    {
                        throw new ValueOutOfRangeException(1, 4, String.Format("Try again,"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }

                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }

                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            return (MotorCycle.eLisenceType)liscenceTypeChoice;
        }
        public void CreateTruck(string i_liscencePlateNumber, out Vehicle io_newVehicle)
        {
            EnergySystem energySystem;
            string modelName = GetModelName();
            bool isDrivingDangerousMaterials = isTruckDrivingDangerousMaterials();
            float maxCarryWeight = getMaxCarryWeight();
            float currAmountOfFuel = getInitialAmountOfGas();
            float currentAirPressure = GetCurrentAirPressure();
            string wheelsMakerName = GetWheelsMakerName();
            energySystem = new FuelSystem(FuelSystem.eFuelType.Soler, 120.0f, currAmountOfFuel);
            io_newVehicle = new Truck(energySystem, isDrivingDangerousMaterials, maxCarryWeight, currAmountOfFuel, modelName, i_liscencePlateNumber, currentAirPressure, wheelsMakerName, Vehicle.eVehicleType.Truck);
        }
        public string GetWheelsMakerName()
        {
            string wheelsMakerName;

            Console.WriteLine("Please type the wheels's maker name: ");
            wheelsMakerName = Console.ReadLine();
            while (!StringValidation.ContainsOnlyLetters(wheelsMakerName))
            {
                Console.WriteLine("Please type the wheels's maker name using only letters: ");
                wheelsMakerName = Console.ReadLine();
            }

            return wheelsMakerName;
        }
        public float GetCurrentAirPressure()
        {
            string userInput;
            float currAirPressure = 0;

            Console.WriteLine("please insert your current air pressure: ");
            userInput = Console.ReadLine();
            while (!float.TryParse(userInput, out currAirPressure))
            {
                Console.WriteLine("Please insert a number ");
                userInput = Console.ReadLine();
            }

            return currAirPressure;
        }
        public string GetModelName()
        {
            string modelName;

            Console.WriteLine("Please type the vehicle's model name: ");
            modelName = Console.ReadLine();
            while (!StringValidation.ContainsOnlyLetters(modelName))
            {
                Console.WriteLine("Please type the vehicle's model name using only letters: ");
                modelName = Console.ReadLine();
            }

            return modelName;
        }
        private float getMaxCarryWeight()
        {
            string userInput;
            float maxWeight;

            Console.WriteLine("Please insert the maximum weight the truck can carry: ");
            userInput = Console.ReadLine();
            while (!float.TryParse(userInput, out maxWeight))
            {
                Console.WriteLine("Please insert the max weight: ");
                userInput = Console.ReadLine();
            }

            return maxWeight;
        }
        private bool isTruckDrivingDangerousMaterials()
        {
            string userInput;
            bool isDrivingDangerousMaterials;
            int userChoice = 0;
            bool isUserInputValid = false;
            bool isInt = false;

            Console.WriteLine("Is the truck driving dangerous materials? (1) Yes (2) No");
            userInput = Console.ReadLine();
            while (!isUserInputValid || !isInt)
            {
                try
                {
                    isInt = int.TryParse(userInput, out userChoice);
                    if(!isInt)
                    {
                        throw new FormatException("Please select again from the options above:");
                    }
                    if (userChoice < 1 || userChoice > 2)
                    {
                        throw new ValueOutOfRangeException(1, 2, String.Format("Try again,"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }

                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }

                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            if (userChoice == 1)
            {
                isDrivingDangerousMaterials = true;
            }

            else
            {
                isDrivingDangerousMaterials = false;
            }

            return isDrivingDangerousMaterials;
        }
        private int displayMode()
        {
            string userInput;
            int userChoice = 0;
            bool isUserInputValid = false;
            bool isInt = false;

            Console.WriteLine("If you want to display in a random mode press 1, or press 2 to sort by vehicle status:");
            userInput = Console.ReadLine();

            while (!isUserInputValid || !isInt)
            {
                try
                {
                    isInt = int.TryParse(userInput, out userChoice);
                    if (!isInt)
                    {
                        throw new FormatException("Please select again from the options above:");
                    }
                    if (userChoice < 1 || userChoice > 2)
                    {
                        throw new ValueOutOfRangeException(1, 2, String.Format("Try again,"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }

                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }

                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            return int.Parse(userInput);
        }
        public void DisplayPlateNumbers(int i_displayMode) //random or sorted by status
        {
            Garage.eVehicleStatus statusChoice;

            if (i_displayMode == 1)
            {
                foreach (Vehicle vehicle in Garage.vehiclesInTheGarage.Values)
                {
                    Console.WriteLine(vehicle.LiscencePlateNumber);
                }
            }

            else //sorted by status
            {
                statusChoice = getStatusChoice();

                foreach (Vehicle vehicle in Garage.vehiclesInTheGarage.Values)
                {
                    if (vehicle.VehicleStatus == statusChoice)
                    {
                        Console.WriteLine(vehicle.LiscencePlateNumber);
                    }
                }
            }

            returnToMenu();
        }
        private Garage.eVehicleStatus getStatusChoice()
        {
            string userInput;
            int statusChoice = 0;
            bool isUserInputValid = false;
            bool isInt = false;

            Console.WriteLine("Please select status for filtering: (1) onGoing (2) Fixed (3) Payed");
            userInput = Console.ReadLine();
            while (!isUserInputValid)
            {
                try
                {
                    isInt = int.TryParse(userInput, out statusChoice);
                    if (!isInt)
                    {
                        throw new FormatException("Please select from the options above:");
                    }
                    if (statusChoice < 1 || statusChoice > 3)
                    {
                        throw new ValueOutOfRangeException(1, 3, String.Format("Please select again from the options above:"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    isInt = false;
                }
                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }


            }

            return (Garage.eVehicleStatus)statusChoice;
        }
        public void ChangeStatus(string i_liscencePlateNumber)
        {
            Vehicle vehicle;

            while (!Garage.vehiclesInTheGarage.TryGetValue(i_liscencePlateNumber, out vehicle))
            {
                Console.WriteLine("Vehicle not found!");
                i_liscencePlateNumber = getLiscencePlateNumber();
            }

            Garage.eVehicleStatus newStatus = getNewVehicleStatus();
            m_MyGarage.ChangeVehicleStatus(vehicle, newStatus);
            Console.WriteLine("Status updated successfully!");
            returnToMenu();
        }
        private Garage.eVehicleStatus getNewVehicleStatus()
        {
            string userInput;
            int userChoice = 0;
            bool isUserInputValid = false;
            bool isInt = false;

            Console.WriteLine("Please select the new status of the vehicle: (1) onGoing, (2) Fixed, (3) Payed");
            userInput = Console.ReadLine();
            while (!isUserInputValid || !isInt)
            {
                try
                {
                    isInt = int.TryParse(userInput, out userChoice);
                    if (!isInt)
                    {
                        throw new FormatException("Please select one of the options above:");
                    }
                    if (userChoice < 1 || userChoice > 3)
                    {
                        throw new ValueOutOfRangeException(1, 3, String.Format("Try again,"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }

                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    isInt = false;
                }
                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            return (Garage.eVehicleStatus)userChoice;
        }
        public void InflateWheelsToMax(string i_liscencePlateNumber)
        {
            foreach (var pair in Garage.vehiclesInTheGarage)
            {
                if (pair.Value.LiscencePlateNumber.Equals(i_liscencePlateNumber))
                {
                    foreach (Wheel wheel in pair.Value.WheelList)
                    {
                        wheel.Inflate(wheel.MaxAirPressure);
                    }
                    break;
                }
            }

            Console.WriteLine("Wheels inflated successfully!");
            returnToMenu();
        }
        private float getAmountOfGasToFill(string i_liscencePlateNumber)
        {
            string userInput;
            float amountOfGas = 0;
            Vehicle vehicle;
            bool isFloat = false; ;
            bool isUserInputValid = false;

            Garage.vehiclesInTheGarage.TryGetValue(i_liscencePlateNumber, out vehicle);
            Console.WriteLine("Please choose how much gas do you want to fill: ");
            userInput = Console.ReadLine();
            while (!isUserInputValid || !isFloat)
            {
                try
                {
                    isFloat = float.TryParse(userInput, out amountOfGas);
                    if (!isFloat)
                    {
                        throw new FormatException("Please choose how much gas do you want to fill (numbers only):");
                    }
                    if ((vehicle.EnergySystem as FuelSystem).MaxFuelCapacity < amountOfGas || amountOfGas < 0)
                    {
                        throw new ValueOutOfRangeException(0, (vehicle.EnergySystem as FuelSystem).MaxFuelCapacity, String.Format("Try again,"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }

                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    isFloat = false;
                }
                if (!isFloat || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            return amountOfGas;
        }
        public void FuelVehicle(string i_liscencePlateNumber)
        {
            Vehicle vehicle;
            bool wrongFuelType = false;
            FuelSystem.eFuelType fuelType = 0;
            float howMuchFuel = getAmountOfGasToFill(i_liscencePlateNumber);

            Garage.vehiclesInTheGarage.TryGetValue(i_liscencePlateNumber, out vehicle);
            try
            {
                fuelType = getTypeOfGasToFill(i_liscencePlateNumber);
            }

            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                wrongFuelType = true;
            }

            m_MyGarage.FuelVehicle(i_liscencePlateNumber, fuelType, howMuchFuel);
            if (!wrongFuelType)
            {
                Console.WriteLine("Vehicle fueled successfully!");
            }
            returnToMenu();
        }

        private FuelSystem.eFuelType getTypeOfGasToFill(string i_liscencePlateNumber)
        {
            string userInput;
            int userChoice = 0;
            bool isUserInputValid = false;
            bool isInt = false;
            Vehicle vehicle;

            Console.WriteLine("Please choose type of gas to fill: (1) Soler  (2) Octan95  (3) Octan96  (4) Octan98");
            userInput = Console.ReadLine();
            while (!isUserInputValid || !isInt)
            {
                try
                {
                    isInt = int.TryParse(userInput, out userChoice);
                    if (!isInt)
                    {
                        throw new FormatException("Please choose how much gas do you want to fill (numbers only):");
                    }
                    if (userChoice < 1 || userChoice > 4)
                    {
                        throw new ValueOutOfRangeException(1, 4, String.Format("Please select one of the options above"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }

                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    isInt = false;
                }
                if (!isInt || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }

            Garage.vehiclesInTheGarage.TryGetValue(i_liscencePlateNumber, out vehicle);
            if ((FuelSystem.eFuelType)userChoice != vehicle.FuelType)
            {
                throw new ArgumentException("The type of fuel you chose doesn't match the vehicle's fuel type! Failed to complete the action.");
            }

             return (FuelSystem.eFuelType)userChoice;
        }
        private float howMuchTimeToCharge(string i_liscencePlateNumber)
        {
            string userInput;
            float timeToCharge = 0;
            Vehicle vehicle;
            bool isUserInputValid = false;
            bool isFloat = false;

            Garage.vehiclesInTheGarage.TryGetValue(i_liscencePlateNumber, out vehicle);
            Console.WriteLine("Please choose how much time to charge the battery: ");
            userInput = Console.ReadLine();
            while (!isUserInputValid || !isFloat)
            {
                try
                {
                    isFloat = float.TryParse(userInput, out timeToCharge);
                    if (!isFloat)
                    {
                        throw new FormatException("Please choose how much time to charge the car (numbers only):");
                    }
                    if (timeToCharge > (vehicle.EnergySystem as ElectricSystem).MaxChargeInHours || timeToCharge < 0)
                    {
                        throw new ValueOutOfRangeException(0, (vehicle.EnergySystem as ElectricSystem).MaxChargeInHours, String.Format("Try again,"));
                    }
                    isUserInputValid = true;
                }

                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.ToString());
                    isUserInputValid = false;
                }

                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    isFloat = false;
                }
                if (!isFloat || !isUserInputValid)
                {
                    userInput = Console.ReadLine();
                }
            }


            return timeToCharge;
        }
        public void ChargeElectricCar(string i_liscencePlateNumber)
        {
            float howMuchTime = howMuchTimeToCharge(i_liscencePlateNumber);
            m_MyGarage.ChargeVehicle(i_liscencePlateNumber, howMuchTime);

            Console.WriteLine("Vehicle battery charged successfully!");
            returnToMenu();
        }
        public void DisplayVehicleInfo(string i_liscencePlateNumber)
        {
            Vehicle vehicle;
            Garage.vehiclesInTheGarage.TryGetValue(i_liscencePlateNumber, out vehicle);

            StringBuilder vehicleInfo = new StringBuilder(vehicle.ToString());
            vehicleInfo.AppendFormat(vehicle.EnergySystem.ToString());
            vehicleInfo.AppendFormat(vehicle.WheelList[0].ToString());
            Console.WriteLine(vehicleInfo);
            returnToMenu();
        }
    }
}
