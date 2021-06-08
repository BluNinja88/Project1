using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IdealGasCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable and Array Declerations & Intializations
            String[] gasNames = new string[200];
            String gasName;
            double[] molecularWeights = new double[200];
            int count;
            int countGases;
            double mass;
            double vol;
            double temp;
            double molecularWeight;
            double pressure;
            string answer;

            //Methods Called
            DisplayHeader();
            GetMolecularWeights(ref gasNames, ref molecularWeights, out count);
            countGases = count;
            DisplayGasNames(gasNames, countGases);

            //Do While Loop:
            do
            {
                Console.WriteLine("\n\nGas Calculation Data:");
                do
                {
                    Console.WriteLine("\nEnter a gas name from the list above (captalizing the first letter): ");
                    gasName = System.Console.ReadLine();
                    molecularWeight = GetMolecularWeightFromName(gasName, gasNames, molecularWeights, countGases);

                    if (molecularWeight == -1)
                    {
                        Console.WriteLine("\n\nError: Please try again.");

                    }
                } while (molecularWeight == -1);

                //Ask User for Gas Variable Values
                Console.WriteLine("Enter the mass of the gas in grams: ");
                mass = Double.Parse(System.Console.ReadLine());
                Console.WriteLine("Enter the temperature of the gas in degrees celcius: ");
                temp = Double.Parse(System.Console.ReadLine());
                Console.WriteLine("Enter the volume of the gas in cubic meters: ");
                vol = Double.Parse(System.Console.ReadLine());

                //Returns pressure of the gas in pascals
                pressure = Pressure(mass, vol, temp, molecularWeight);

                //Writes Pressure results to the console
                DisplayPresure(pressure);

                //Ask user to play again
                Console.WriteLine("\n\nWould you like to do another gas calculation (y/n)? ");
                answer = Console.ReadLine();
            } while (answer == "y");

            //Goodbye Message
            Console.WriteLine("\n\nThank you for using the Ideal Gas Calculater! Goodbye! :)");
        }

        //Methods

        //Class Header
        static void DisplayHeader()
        {
            Console.WriteLine("\n\nWelcome to The Ideal Gas Calculator!\n\n");
        }


        //Reads CSV File and Fills Array with Gas Names and Molecular Weight of Each Gas
        static void GetMolecularWeights(ref string[] gasNames, ref double[] molecularWeights, out int count)
        {
            //Variable
            count = 0;

            //Use StreamReader to open and read the csv file
            StreamReader mW = new StreamReader("MolecularWeightsGasesAndVapors.csv");
            string getMoleWeight = mW.ReadLine();

      
            while ((getMoleWeight = mW.ReadLine()) != null)
            {
                string[] parsedLine = getMoleWeight.Split(',');
                gasNames[count] = parsedLine[0];
                molecularWeights[count] = double.Parse(parsedLine[1]);

                count++;
            }

            //Close csv File
            mW.Close();
        }


        //Display Names of Gases in 3 Columns
        private static void DisplayGasNames(string[] gasNames, int countGases)
        {
            //Adds gasName Array into 3 columns
            for (int i = 0; i < countGases;)
            {
                //Displays the Gas Names 3 to a Row                 
                System.Console.WriteLine("{0,-20} {1, -20} {2, -20}", gasNames[i], gasNames[i + 1], gasNames[i + 2]);
                i += 3;
            }

        }


        //Reads Array for User Gas Name & Returns its Weight in Mols
        private static double GetMolecularWeightFromName(string gasName, string[] gasNames, double[] molecularWeights, int countGases)
        {
            //Variable
            double error = -1;

            //Counts elements in the array 
            for (int i = 0; i < countGases; i++)
            {
                //Converts molecularWeight into gases weight in mols and returns mol weight
                if (gasNames[i] == gasName)
                {
                    Console.WriteLine("\n\n" + gasName + ": " + molecularWeights[i]);
                    return molecularWeights[i];
                }
            }

            return error;
        }

        //Calculates the Pressure of the Gas in Pascals
        static double Pressure(double mass, double vol, double temp, double molecularWeight)
        {
            //Variable                               
            double mol;
            double kelvin;
            double celcius = temp;
            double R = 8.3145;

            //Calling Functions
            mol = NumberOfMoles(mass, molecularWeight);
            //converts mass to molecular weight
            kelvin = CelciusToKelvin(celcius);
            //returns temperature of gas in Kelvin

            //Calculate: pressure in pascals
            double pressure = (mol * R * kelvin) / vol;

            //Return pressure of gas in pascals            
            return pressure;
        }


        //Converts Molecular Weight to Mols
        static double NumberOfMoles(double mass, double molecularWeight)
        {
            //Variable 
            double Moles;

            //Conversion Calculation 
            Moles = mass / molecularWeight;

            //Returns Molecular Weight in Moles
            return Moles;
        }


        //Converts Temperature Celsius to Kelvin
        static double CelciusToKelvin(double celcius)
        {
            //Variable 
            double kelvin;

            //Conversion Calculation
            kelvin = celcius + 273;

            //Returns Tempurature in Kelvin            
            return kelvin;
        }


        //Displays Pressure Calculation Results in Pascals and PSI
        private static void DisplayPresure(double pressure)
        {
            //Variable Decleration
            double psi;
            double pascals = pressure;

            //convert pascals to PSI
            psi = PaToPSI(pascals);

            //Display Pressure Results
            Console.WriteLine("\n\n          Calculation Results");
            Console.WriteLine("\nPressure in Pascals: " + pressure + " Pa");
            Console.WriteLine("Pressure in PSI: " + psi + " psi");
        }


        //Converts Pressure Results in Pascals to PSI
        static double PaToPSI(double pascals)
        {
            //Variable 
            double psi;

            //Conversion Calculation
            psi = .000145038 * pascals;

            //Returns pressure result in psi         

            return psi;
        }

    }

}
