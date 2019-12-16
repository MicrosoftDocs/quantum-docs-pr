using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Convert;

namespace Quantum{
    class Driver
    {
        static void Main(string[] args)
        {
            using (var sim = new QuantumSimulator())
            {
                // First we initialize all the variables:
                string bit_string = "0"; // To save the bit string
                string a = "0"; // Auxiliary string variable
                int Max = 50; // The maximum of the range 
                bool b = false; // Auxiliary bool
                int size = Convert.ToInt32(Math.Floor(Math.Log(Max, 2.0) + 1));
                // To calculate the amount of needed bits
                int output = Max + 1; // Int to store the output
                while(output > Max){ // Loop to generate the number
                    bit_string = "0"; // Restart the bit string if fails 
                    for(int counter = 0; counter < size ; counter++){
                        b = (QuantumRandomNumberGenerator.Run(sim).Result == Result.One); 
                        // Call the Q# operation and transform the resutl to bool
                        a = b ? "0" : "1"; // Transform the bool to string
                        bit_string = bit_string + a; // Concatenate bits
                    }
                    output = Convert.ToInt32(bit_string, 2);
                    // Convert the bit string to an integer
                }
                Console.WriteLine("The random number generated is " 
                + output.ToString());
                // Print the result
            }
         }
      }
    }
