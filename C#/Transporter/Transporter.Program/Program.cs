// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Transporter.Program
{
    using System;
    using Transporter.Logic;

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
            int param = 100;

            while (param != 0)
            {
                Console.Clear();

                Console.WriteLine("Exit: 0");
                Console.WriteLine("Retrive customers: 1");
                Console.WriteLine("Retrive pakages: 2");
                Console.WriteLine("Retrive drivers: 3");
                Console.WriteLine("Add new customer: 4");
                Console.WriteLine("Add new pakage: 5");
                Console.WriteLine("Add new driver: 6");
                Console.WriteLine("Change customer adress: 7");
                Console.WriteLine("Change pakage driver: 8");
                Console.WriteLine("Change driver: 9");
                Console.WriteLine("Delete customer: 10");
                Console.WriteLine("Delete pakage: 11");
                Console.WriteLine("Delete driver: 12");
                Console.WriteLine("Retrive every table: 13");
                Console.WriteLine("Retrive pakage driver: 14");
                Console.WriteLine("Change pakage driver: 15");
                Console.WriteLine("Retrive pakages full route: 16");
                Console.WriteLine("Get price and transport time estimate: 17");

                string input = Console.ReadLine();
                if (input != string.Empty)
                {
                    param = int.Parse(input);
                    Execute(param);
                }
            }
        }

        /// <summary>
        /// Executes the chosen operation.
        /// </summary>
        /// <param name="param">The number of the chosen operation.</param>
        private static void Execute(int param)
        {
            Logic logic = new Logic();

            switch (param)
            {
                case 0:
                    Console.Clear();

                    Console.WriteLine("Press any key to exit.");
                    break;
                case 1:
                    Console.Clear();

                    string[] ctable = logic.RetriveCustomers();

                    foreach (var item in ctable)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 2:
                    Console.Clear();

                    string[] ptable = logic.RetrivePakages();

                    foreach (var item in ptable)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 3:
                    Console.Clear();

                    string[] dtable = logic.RetriveDrivers();

                    foreach (var item in dtable)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 4:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 5:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 6:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 7:
                    Console.WriteLine("Not Implemented.");
                    break;
                case 8:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 9:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 10:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 11:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 12:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 13:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 14:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 15:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 16:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                case 17:
                    Console.Clear();

                    Console.WriteLine("Not Implemented.");
                    break;
                default:
                    Console.Clear();

                    Console.WriteLine("Give a number between 0 and 17!");
                    break;
            }

            Console.ReadKey();
        }
    }
}
