using System;
using System.Linq;
using NUnit.Framework;
using TestWebApp.TestModels;

namespace UnitTests
{
    public class Tests
    {
        private SimpleTestClass testClass;

        [SetUp]
        public void Setup()
        {
            this.testClass = new SimpleTestClass();
        }

        [Test]
        [TestCase(1,2,3)]
        [TestCase(10,20,30)]
        [TestCase(-1,0,1)]
        public void TestSum(params int[] values)
        {
            int sum = values.Sum();
            
            Assert.AreEqual(sum,testClass.Summ(values));
        }
    }
}