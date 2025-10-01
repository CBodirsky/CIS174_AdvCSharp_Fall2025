using System;
using Xunit;
using M1T2_FirstResponsiveWebAppBodirsky.Models;

namespace UserAgeUnittests
{
    public class UnitTest1
    {
        [Fact]
        public void AgeThisYear_CorrectAge()
        {
            var model = new UserAgeModel
            {
                Birthday = new DateTime(1990, 5, 15)
            };
            int result = model.AgeThisYear();

            Assert.Equal(DateTime.Now.Year - 1990, result);
        }

        [Theory]
        [InlineData("2000-01-01", true)]
        [InlineData("2000-12-31", false)]
        public void AgeToday_NotOccurred(string birthdayString,  bool birthdayPassed)
        {
            var birthday = DateTime.Parse(birthdayString);
            var model = new UserAgeModel { Birthday = birthday };

            int expectedAge = DateTime.Today.Year - birthday.Year;
            if (!birthdayPassed) expectedAge--;

            int result = model.AgeToday();

            Assert.Equal(expectedAge, result);
        }

        [Fact]
        public void AgeThisYear_Exception_BirthdayNull()
        {
            var model = new UserAgeModel { Birthday = null };
            Assert.Throws<InvalidOperationException>(() => model.AgeThisYear());
        }

        [Fact]
        public void AgeToday_ReturnsZero_BirthdayToday()
        {
            var today = DateTime.Today;
            var model = new UserAgeModel { Birthday = today };
            Assert.Equal(0, model.AgeToday());
        }

        [Fact]
        public void AgeToday_Negative_BirthdayInFuture()
        {
            var futureDate = DateTime.Today.AddYears(1);
            var model = new UserAgeModel { Birthday = futureDate };
            Assert.Equal(-1, model.AgeToday());
        }

        [Fact]
        public void AgeToday_HandlesLeapYearBirthday()
        {
            var leapBirthday = new DateTime(2000, 2, 29);
            var model = new UserAgeModel { Birthday = leapBirthday };
            int expectedAge = DateTime.Today.Year - 2000;
            if (DateTime.Today < new DateTime(DateTime.Today.Year, 2, 28)) expectedAge--;

            Assert.Equal(expectedAge, model.AgeToday());
        }

        [Fact]
        public void AgeThisYear_HandlesMinimumDate()
        {
            var model = new UserAgeModel { Birthday = DateTime.MinValue };
            int expectedAge = DateTime.Now.Year - DateTime.MinValue.Year;
            Assert.Equal(expectedAge, model.AgeThisYear());
        }


    }
}