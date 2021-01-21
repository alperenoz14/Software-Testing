using NUnit.Framework;
using Software_Testing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Testing.Tests
{
    [TestFixture]
    public class NunitTest
    {
        GuessService GuessService = new GuessService();

        [Test]
        public void GuessTest()
        {
            var result = GuessService.Guess("This is a test description with less then 20 words.");
            Assert.AreEqual("1-3 Gün", result);
        }

        [Test]
        public void GuessTest2()
        {
            var result = GuessService.Guess("This is a test description with less then 20 words.");
            Assert.AreNotEqual("3-5 Gün", result);
        }
    }
}
