using NUnit.Framework;
using System;

namespace AgeCalculator
{
    [TestFixture]
    public class AgeCalculatorUseCase
    {
        [Test]
        public void CalculateAge_GivenToday_ShouldReturn0()
        {
            //Arrange
            string birthday = DateTime.Today.ToString("yyyy/MM/dd");
            string targetDate = DateTime.Today.ToString("yyyy/MM/dd");

            //Act
            int actual = Calculate(birthday, targetDate);
            int expected = 0;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase("1982/09/30", "2001/10/05", 19)]
        [TestCase("1993/10/27", "2020/04/20", 26)]
        [TestCase("1995/06/19", "2020/04/20", 24)]
        [TestCase("2001/05/20", "2016/05/19", 14)]
        public void CalculateAge_GivenDate_AndTargetDate_ShouldReturnAge(string givenDate, string targetDate, int expected)
        {
            //Act
            int actual = Calculate(givenDate, targetDate);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAge_GivenDateAfterTargetDate_ShouldThrowException()
        {
            //Arrange
            string birthday = "2020/05/19";
            string targetDate = "2020/05/18";
            string expected = "Cannot calculate age if person hasn't been born yet";
            
            //Act
            var actual = Assert.Throws<Exception>(() => Calculate(birthday, targetDate));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        private int Calculate(string givenDate, string targetDate)
        {
            DateTime convertedGivenDate = Convert.ToDateTime(givenDate);
            DateTime convertedTargetDate = Convert.ToDateTime(targetDate);

            if (convertedGivenDate > convertedTargetDate)
                throw new Exception("Cannot calculate age if person hasn't been born yet");

            int age = convertedTargetDate.Year - convertedGivenDate.Year;

            if (convertedGivenDate > convertedTargetDate.AddYears(-age))
                age--;

            return age;
        }
    }
}
