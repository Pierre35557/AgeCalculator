using NUnit.Framework;
using System;

namespace AgeCalculator
{
    [TestFixture]
    public class AgeCalculatorUseCase
    {
        [TestCase("1982/09/30", "2001/10/05", 19)]
        [TestCase("1993/10/27", "2020/04/20", 26)]
        [TestCase("1995/06/19", "2020/04/20", 24)]
        [TestCase("2001/05/20", "2016/05/19", 14)]
        public void CalculateAge_GivenDate_AndTargetDate_ShouldReturnAgeInYears(string givenDate, string targetDate, int expected)
        {
            //Act
            int actual = Calculate(givenDate, targetDate);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private int Calculate(string givenDate, string targetDate)
        {
            DateTime convertedGivenDate = Convert.ToDateTime(givenDate);
            DateTime convertedTargetDate = Convert.ToDateTime(targetDate);

            int age = convertedTargetDate.Year - convertedGivenDate.Year;

            if (convertedGivenDate > convertedTargetDate.AddYears(-age))
                age--;

            return age;
        }
    }
}
