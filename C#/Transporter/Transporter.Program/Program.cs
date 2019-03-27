// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Transporter.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Main class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method, handels the menu system.
        /// </summary>
        /// <param name="args">Main method argument.</param>
        private static void Main(string[] args)
        {
            int param = -1
                ;

            while (param != 0)
            {
                Console.WriteLine("Exit: 0");
                Console.WriteLine("Retrive customers: 1");
                Console.WriteLine("Retrive pakages: 2");
                Console.WriteLine("Retrive drivers: 3");
                Console.WriteLine("Add new customer: 4");
                Console.WriteLine("Add new pakage: 5");
                Console.WriteLine("Add new driver: 6");
                Console.WriteLine("Delete customer: 7");
                Console.WriteLine("Delete pakage: 8");
                Console.WriteLine("Delete driver: 9");
                Console.WriteLine("Change customer: 10");
                Console.WriteLine("Change pakage: 11");
                Console.WriteLine("Change driver: 12");

                param = int.Parse(Console.ReadLine());

                Execute(param);
            }
        }

        /// <summary>
        /// Executes the chosen operation.
        /// </summary>
        /// <param name="param">The number of the chosen operation.</param>
        private static void Execute(int param)
        {
            switch (param)
            {
                case 0:
                    Console.WriteLine("Press a key to exit.");
                    break;
                case 1:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 2:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 3:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 4:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 5:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 6:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 7:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 8:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 9:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 10:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 11:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 12:
                    Console.WriteLine("Not Implemented.");
                    break;
                default:
                    Console.WriteLine("Give a number between 0 and 15!");
                    break;
            }

            Console.ReadKey();
        }
    }
}
