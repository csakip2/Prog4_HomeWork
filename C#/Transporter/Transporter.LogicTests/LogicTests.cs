// <copyright file="LogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Transporter.LogicTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using Transporter.Data;
    using Transporter.Logic;
    using Transporter.Repository;

    /// <summary>
    /// Test class for Logic.
    /// </summary>
    [TestFixture]
    public class LogicTests
    {
        private Mock<ICustomerRepository> moqCustRepo;
        private Mock<IPakageRepository> moqPakRepo;
        private Mock<IDriverRepository> moqDrivRepo;

        private Logic logic;

        /// <summary>
        /// Sets up the mocked repositories before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.moqCustRepo = new Mock<ICustomerRepository>();
            this.moqPakRepo = new Mock<IPakageRepository>();
            this.moqDrivRepo = new Mock<IDriverRepository>();
        }

        /// <summary>
        /// Tests the GetCustomer method.
        /// </summary>
        [Test]
        public void TestGetCustomers()
        {
            List<string[]> customers = new List<string[]>()
            {
                new string[] { "1", "Aladar", "Alma ut 8", "aladar52@bamil.com", "303652736" },
                new string[] { "2", "Bela", "Bagoly utca 2", "b.ela_87@gmail.com", "205489264" },
                new string[] { "3", "Cecil", "Cekla ter 12", "cecik43@freemail.hu", "705286418" },
                new string[] { "4", "Denes", "Darvas ut 3", "deneske11@hotmail.com", "301753982" },
                new string[] { "5", "Elemer", "Egyetem ter 5", "elemer23@gmail.com", "707258464" }
            };

            this.moqCustRepo.Setup(m => m.GetTable()).Returns(customers);

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            var res = this.logic.RetriveCustomers();

            Assert.That(res.Count(), Is.EqualTo(5));
        }

        /// <summary>
        /// Tests the GetCustomer methods return format.
        /// </summary>
        [Test]
        public void TestGetCustomerFortat()
        {
            this.moqCustRepo.Setup(m => m.GetTable()).Returns(new List<string[]>() { new string[] { "1", "abc", "abc", "abc", "123" } });

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            var res = this.logic.RetriveCustomers();

            Assert.That(res[0], Is.EqualTo("1, abc, abc, abc, 123"));
        }

        /// <summary>
        /// Tests for customer insertion.
        /// </summary>
        [Test]
        public void TestInsertCustomers()
        {
            this.moqCustRepo.Setup(m => m.Insert(1, "abc", "abc", "abc", "123"));

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            this.logic.AddCustomer("abc", "abc", "abc", "123");

            this.moqCustRepo.Verify(m => m.Insert(1, "abc", "abc", "abc", "123"), Times.Exactly(1));
            this.moqCustRepo.Verify(m => m.LastId, Times.Exactly(1));
        }

        /// <summary>
        /// Tests customer adress change.
        /// </summary>
        [Test]
        public void TestChangeCustomerAdress()
        {
            this.moqCustRepo.Setup(m => m.ChangeAdress(0, "cba"));

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            this.logic.ChangeCustomerAdress("abc", "abc", "cba");

            this.moqCustRepo.Verify(m => m.ChangeAdress(0, "cba"), Times.Exactly(1));
        }

        /// <summary>
        /// Tests customer e-mail adress change.
        /// </summary>
        [Test]
        public void TestChangeCustomerE_mailAdress()
        {
            this.moqCustRepo.Setup(m => m.ChangeEmail(0, "cba"));

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            this.logic.ChangeCustomerEmail("abc", "abc", "cba");

            this.moqCustRepo.Verify(m => m.ChangeEmail(0, "cba"), Times.Exactly(1));
        }

        /// <summary>
        /// Tests customer adress change.
        /// </summary>
        [Test]
        public void TestChangeCustomerPhoneNum()
        {
            this.moqCustRepo.Setup(m => m.ChangePhoneNum(0, "123"));

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            this.logic.ChangeCustomerPhoneNum("abc", "abc", "123");

            this.moqCustRepo.Verify(m => m.ChangePhoneNum(0, "123"), Times.Exactly(1));
        }

        /// <summary>
        /// Tests
        /// </summary>
        [Test]
        public void TestGetDrivers()
        {
            List<string[]> drivers = new List<string[]>()
            {
                new string[] { "1", "Aladar", "Alma ut 8", "1970", "asd653", "303652736" },
                new string[] { "2", "Bela", "Bagoly utca 2", "1980", "rtz423", "205489264" },
                new string[] { "3", "Cecil", "Cekla ter 12", "1960", "abc123", "705286418" }
            };

            this.moqDrivRepo.Setup(m => m.GetTable()).Returns(drivers);

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            var res = this.logic.RetriveDrivers();

            Assert.That(res.Count(), Is.EqualTo(3));
        }

        /// <summary>
        /// Tests the GetDriver methods return format.
        /// </summary>
        [Test]
        public void TestGetDirverFortat()
        {
            this.moqDrivRepo.Setup(m => m.GetTable()).Returns(new List<string[]>() { new string[] { "1", "Aladar", "Alma ut 8", "1970", "asd653", "303652736" } });

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            var res = this.logic.RetriveDrivers();

            Assert.That(res[0], Is.EqualTo("1, Aladar, Alma ut 8, 1970, asd653, 303652736"));
        }

        /// <summary>
        /// Tests ChangeDriverAdress method.
        /// </summary>
        [Test]
        public void TestChangeDriverAdress()
        {
            this.moqDrivRepo.Setup(m => m.ChangeAdress(0, "abc"));

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            this.logic.ChangeDriverAdress("abc", "abc", "abc");

            this.moqDrivRepo.Verify(m => m.ChangeAdress(0, "abc"), Times.Exactly(1));
        }

        /// <summary>
        /// Tests ChangeDriverLicencePlate method.
        /// </summary>
        [Test]
        public void TestChangeDriverLicencePlate()
        {
            this.moqDrivRepo.Setup(m => m.ChangeLicPlate(0, "abc"));

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            this.logic.ChangeDriverLicPlate("abc", "abc", "abc123");

            this.moqDrivRepo.Verify(m => m.ChangeLicPlate(0, "abc123"), Times.Exactly(1));
        }

        /// <summary>
        /// Tests ChangeDriverLicencePlate method.
        /// </summary>
        [Test]
        public void TestChangeDriverPhoneNumber()
        {
            this.moqDrivRepo.Setup(m => m.ChangePhoneNum(0, "abc"));

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            this.logic.ChangeDriverPhoneNum("abc", "abc", "abc");

            this.moqDrivRepo.Verify(m => m.ChangePhoneNum(0, "abc"), Times.Exactly(1));
        }

        /// <summary>
        /// Tests the GetPakages method.
        /// </summary>
        [Test]
        public void TestGetPakage()
        {
            List<string[]> pakages = new List<string[]>()
            {
                new string[] { "1", "SMALL", "1", "1", "2", "3" },
                new string[] { "2", "MEDIUM", "1", "1", "2", "3" },
                new string[] { "3", "LARGE", "1", "1", "2", "3" }
            };

            this.moqPakRepo.Setup(m => m.GetTable()).Returns(pakages);

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            var res = this.logic.RetrivePakages();

            Assert.That(res.Count(), Is.EqualTo(3));
        }

        /// <summary>
        /// Tests the return format of GetPakages.
        /// </summary>
        [Test]
        public void TestGetPakagesFormat()
        {
            this.moqPakRepo.Setup(m => m.GetTable()).Returns(new List<string[]>() { new string[] { "1", "SMALL", "1", "1", "2", "3" } });

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            var res = this.logic.RetrivePakages();

            Assert.That(res[0], Is.EqualTo("1, SMALL, 1, 1, 2, 3"));
        }
    }
}
