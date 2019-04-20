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
                Console.WriteLine("Change customer phone number: 8");
                Console.WriteLine("Change customer e-mail: 9");
                Console.WriteLine("Change driver adress: 10");
                Console.WriteLine("Change driver licence plate: 11");
                Console.WriteLine("Change driver phone number: 12");
                Console.WriteLine("Change pakage driver: 13");
                Console.WriteLine("Get pakages driver: 14");
                Console.WriteLine("Get pakages route: 15");
                Console.WriteLine("Delete customer: 16");
                Console.WriteLine("Delete pakage: 17");
                Console.WriteLine("Delete driver: 18");
                Console.WriteLine("Get price and transport time estimate: 19");

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
            string name = string.Empty;
            string adress = string.Empty;
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

                    string phoneNum = string.Empty,
                        e_mail = string.Empty;

                    Console.WriteLine("Name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Adress:");
                    adress = Console.ReadLine();

                    Console.WriteLine("Phone Number");
                    phoneNum = Console.ReadLine();

                    Console.WriteLine("E-Mail Adress");
                    e_mail = Console.ReadLine();

                    logic.AddCustomer(name, adress, phoneNum, e_mail);

                    Console.WriteLine();
                    Console.WriteLine("Added successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 5:
                    Console.Clear();

                    string senderName = string.Empty,
                        senderAdress = string.Empty,
                        reciverName = string.Empty,
                        reciverAdress = string.Empty,
                        size = string.Empty;
                    int weight = 0;
                    bool ok = false;

                    Console.WriteLine("Sender name:");
                    senderName = Console.ReadLine();

                    Console.WriteLine("Sender adress:");
                    senderAdress = Console.ReadLine();

                    Console.WriteLine("Reciver name:");
                    reciverName = Console.ReadLine();

                    Console.WriteLine("Reciver adress:");
                    reciverAdress = Console.ReadLine();

                    Console.WriteLine("Size (small, medium, large):");
                    while (!ok)
                    {
                        size = Console.ReadLine().ToUpper();

                        if (size == "SMALL" || size == "MEDIUM" || size == "LARGE")
                        {
                            ok = true;
                        }
                        else
                        {
                            Console.WriteLine("Size has to be small, medium or large.");
                        }
                    }

                    Console.WriteLine("Weight (kg):");
                    weight = int.Parse(Console.ReadLine());

                    logic.AddPakage(senderName, senderAdress, reciverName, reciverAdress, weight, size);

                    Console.WriteLine();
                    Console.WriteLine("Added successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 6:
                    Console.Clear();

                    string licencePlate = string.Empty,
                        driverPhoneNum = string.Empty;

                    DateTime birthDate = DateTime.Now;

                    Console.WriteLine("Name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Adress:");
                    adress = Console.ReadLine();

                    Console.WriteLine("Date of birth (YYYY.MM.DD):");
                    birthDate = DateTime.ParseExact(Console.ReadLine(), "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture);

                    Console.WriteLine("Phone Number");
                    driverPhoneNum = Console.ReadLine();

                    Console.WriteLine("E-Mail Adress");
                    licencePlate = Console.ReadLine();

                    logic.AddDriver(name, adress, birthDate, licencePlate, driverPhoneNum);

                    Console.WriteLine();
                    Console.WriteLine("Added successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 7:
                    Console.Clear();

                    string oldAdress = string.Empty,
                        newAdress = string.Empty;

                    Console.WriteLine("Name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Old adress:");
                    oldAdress = Console.ReadLine();

                    Console.WriteLine("New adress:");
                    newAdress = Console.ReadLine();

                    logic.ChangeCustomerAdress(name, oldAdress, newAdress);

                    Console.WriteLine();
                    Console.WriteLine("Changed successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 8:
                    Console.Clear();

                    string newPhoneNum = string.Empty;

                    Console.WriteLine("Name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Adress:");
                    adress = Console.ReadLine();

                    Console.WriteLine("New phone number:");
                    newPhoneNum = Console.ReadLine();

                    logic.ChangeCustomerPhoneNum(name, adress, newPhoneNum);

                    Console.WriteLine();
                    Console.WriteLine("Changed successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 9:
                    Console.Clear();

                    string newE_Mail = string.Empty;

                    Console.WriteLine("Name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Adress:");
                    adress = Console.ReadLine();

                    Console.WriteLine("New e-mail adress:");
                    newE_Mail = Console.ReadLine();

                    logic.ChangeCustomerEmail(name, adress, newE_Mail);

                    Console.WriteLine();
                    Console.WriteLine("Changed successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 10:
                    Console.Clear();

                    Console.WriteLine("Name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Old adress:");
                    oldAdress = Console.ReadLine();

                    Console.WriteLine("New adress:");
                    newAdress = Console.ReadLine();

                    logic.ChangeDriverAdress(name, oldAdress, newAdress);

                    Console.WriteLine();
                    Console.WriteLine("Changed successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 11:
                    Console.Clear();

                    string newLicPlate = string.Empty;

                    Console.WriteLine("Name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Adress:");
                    adress = Console.ReadLine();

                    Console.WriteLine("New licence plate number:");
                    newLicPlate = Console.ReadLine();

                    logic.ChangeDriverLicPlate(name, adress, newLicPlate);

                    Console.WriteLine();
                    Console.WriteLine("Changed successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 12:
                    Console.Clear();

                    Console.WriteLine("Name:");
                    name = Console.ReadLine();

                    Console.WriteLine("Adress:");
                    adress = Console.ReadLine();

                    Console.WriteLine("New phone number:");
                    newPhoneNum = Console.ReadLine();

                    logic.ChangeDriverPhoneNum(name, adress, newPhoneNum);

                    Console.WriteLine();
                    Console.WriteLine("Changed successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 13:
                    Console.Clear();

                    int pakageId = 0,
                        newDriverId = 0;

                    Console.WriteLine("The pakages ID:");
                    pakageId = int.Parse(Console.ReadLine());

                    Console.WriteLine("The new drivers ID:");
                    newDriverId = int.Parse(Console.ReadLine());

                    logic.ChangePakageDriver(pakageId, newDriverId);

                    Console.WriteLine();
                    Console.WriteLine("Changed successfully.");

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    break;
                case 14:
                    Console.Clear();

                    Console.WriteLine("The pakages ID:");
                    pakageId = int.Parse(Console.ReadLine());

                    string[] driver = logic.GetPakageDriver(pakageId);

                    Console.WriteLine(driver[0] + ", " + driver[1]);
                    break;
                case 15:
                    Console.Clear();

                    Console.WriteLine("The pakages ID:");
                    pakageId = int.Parse(Console.ReadLine());

                    string[] route = logic.GetPakageRoute(pakageId);

                    Console.WriteLine($"From: {route[0]}, to: {route[2]}, driver: {route[2]}");
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
