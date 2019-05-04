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
        private Mock<ICustomerRepository> moqCustRepo = new Mock<ICustomerRepository>();
        private Mock<IPakageRepository> moqPakRepo = new Mock<IPakageRepository>();
        private Mock<IDriverRepository> moqDrivRepo = new Mock<IDriverRepository>();

        private Logic logic;

        /// <summary>
        /// Test for customer GetTable.
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
            this.moqCustRepo.Setup(m => m.Insert(1, "abc", "abc", "abc", "123"));

            this.logic = new Logic(this.moqCustRepo.Object, this.moqPakRepo.Object, this.moqDrivRepo.Object);

            this.logic.AddCustomer("abc", "abc", "abc", "123");

            this.logic.ChangeCustomerAdress("abc", "abc", "cba");

            var res = this.logic.RetriveCustomers();

            Assert.That(res[0], Is.EqualTo(new string[] { "1", "abc", "cba", "abc", "123" }));
        }
    }
}
