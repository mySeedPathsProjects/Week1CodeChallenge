using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Week1CodeChallenge
{
    [TestFixture]
    class Test
    {
        [Test, Timeout(500)]
        public void testFizzBuzz1()
        {
            StringAssert.AreEqualIgnoringCase("1", Program.FizzBuzz(1));
        }
        [Ignore]
        [Test, Timeout(500)]
        public void testFizzBuzzNegative()
        {
            StringAssert.AreEqualIgnoringCase("", Program.FizzBuzz(-1));
        }
        [Test, Timeout(500)]
        public void testFizzBuzz3()
        {
            StringAssert.AreEqualIgnoringCase("Buzz", Program.FizzBuzz(3));
        }
        [Test, Timeout(500)]
        public void testFizzBuzz5()
        {
            StringAssert.AreEqualIgnoringCase("Fizz", Program.FizzBuzz(5));
        }
        [Test, Timeout(500)]
        public void testFizzBuzz3And5()
        {
            StringAssert.AreEqualIgnoringCase("FizzBuzz", Program.FizzBuzz(15));
        }
        [Test, Timeout(500)]


        public void testYodaizerTwoWords()
        {
            StringAssert.AreEqualIgnoringCase("challenge code", Program.Yodaizer("code challenge"));
        }
        [Test, Timeout(500)]
        public void testYodaizerFiveWords()
        {
            StringAssert.AreEqualIgnoringCase("full pot coffee the keep", Program.Yodaizer("Keep the coffee pot full"));
        }
        [Test, Timeout(500)]
        public void testYodaizerBonus()
        {
            StringAssert.AreEqualIgnoringCase("code, I like", Program.Yodaizer("I like code"));
        }
        [Test, Timeout(500)]


        public void testIsPrime1()
        {
            Assert.IsFalse(Program.IsPrime(1));
        }
        [Test, Timeout(500)]
        public void testIsPrime4()
        {
            Assert.IsFalse(Program.IsPrime(4));
        }
        [Test, Timeout(500)]
        public void testIsPrime5()
        {
            Assert.IsTrue(Program.IsPrime(5));
        }
        [Test, Timeout(500)]
        public void testIsPrime7()
        {
            Assert.IsTrue(Program.IsPrime(7));
        }
        [Test, Timeout(500)]
        public void testIsPrime9()
        {
            Assert.IsFalse(Program.IsPrime(9));
        }
        [Test, Timeout(500)]


        public void testDashInsert1()
        {
            StringAssert.AreEqualIgnoringCase("867-5-309", Program.DashInsert(8675309));
        }
        [Test, Timeout(500)]
        public void testDashInsert2()
        {
            StringAssert.AreEqualIgnoringCase("4547-9-3", Program.DashInsert(454793));
        }
    }
}
