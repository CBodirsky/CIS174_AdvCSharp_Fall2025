using System.ComponentModel.DataAnnotations;
namespace M1T2_FirstResponsiveWebAppBodirsky.Models
{
    public class UserAgeModel
    {
        //input validations with attributes
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your birthday.")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        
        //AgeThisYear() method
        public int AgeThisYear()
        {
            int thisYear = DateTime.Now.Year;
            return thisYear - Birthday.Value.Year;
        }
        //Additional AgeToday() method for the extra credit goal
        public int AgeToday()
        {
            DateTime today = DateTime.Today;
            int userAge = today.Year - Birthday.Value.Year;
            if (Birthday.Value.Date > today.AddYears(-userAge)) userAge--;

            return userAge;
        }
    }
}