using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechnicalTest.Models;
using TechnicalTest.Services;

namespace TechnicalTestUnitTest
{
    public class Tests
    {
        IAgeCalculator _ageCalculator = null;
        ILogger<DetailsModel> _logger;

        [SetUp]
        public void Setup()
        { 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateofBirth"></param>
        /// <param name="age"></param>
        /// <param name="month"></param>
        /// <param name="days"></param>
        //In line testdata to run the same testcase multiple for multiple data
        [TestCase("11/29/2023", 0, 0, 1, "")]
        [TestCase("01/20/2000", 23, 10, 11, "")]
        [TestCase("08/01/2025", 0, 0, 0, "Date of birth should not be greater than today's date")]
        public void CalculateAge_Success_Fail(DateTime? dateofBirth, int age,int month,int days,string message)
        {
            //arrange
            _ageCalculator = new AgeCalculator(_logger);

            //act
            var result = _ageCalculator.CalculateAge(dateofBirth);
            days = result.Days;

            // assert
            Assert.That(result.Age, Is.EqualTo(age));
            Assert.That(result.Month, Is.EqualTo(month));
            Assert.That(result.Days, Is.EqualTo(days));
            //to check the invalid date format and verify with the message
            Assert.That(result.Message, Is.EqualTo(message));

        }
    }
}