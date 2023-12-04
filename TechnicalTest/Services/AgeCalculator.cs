using System.Globalization;
using TechnicalTest.Models;

namespace TechnicalTest.Services
{
    public class AgeCalculator : IAgeCalculator
    {
        ILogger<DetailsModel> _logger;
        public AgeCalculator(ILogger<DetailsModel> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateofBirth"></param>
        /// <returns> DetailsModel model which has Age,Month and Days</returns>
        public DetailsModel CalculateAge(DateTime? dateofBirth)
        {
            //This model has Age,Months and Days properties
            DetailsModel detailsModel = new DetailsModel();
            try
            {
                if ( dateofBirth<=DateTime.Now)
                {
                    DateTime currentDate = DateTime.Now;
                    //Age calculation in years
                    detailsModel.Age = new DateTime(DateTime.Now.Subtract(Convert.ToDateTime(dateofBirth)).Ticks).Year - 1;
                    //Months calculation based on previousdate
                    DateTime previousDate = Convert.ToDateTime(dateofBirth).AddYears(detailsModel.Age);
                    detailsModel.Month = GetMonths(previousDate);
                    //Days calculation
                    detailsModel.Days = currentDate.Subtract(previousDate.AddMonths(detailsModel.Month)).Days;
                    detailsModel.Message = string.Empty;
                }
                else
                    //when date is invalid we will return message into description
                    detailsModel.Message = "Date of birth should not be greater than today's date";
            }
            catch (Exception ex)
            {
                //Using loggers to logg the execptions
                _logger.LogInformation("Error occured " + ex.Message + "");
            }
            return detailsModel;
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="previousDate"></param>
        /// <returns>Months calculation logic</returns>
        private int GetMonths(DateTime previousDate)
        {
            int months = 0;
            try
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (previousDate.AddMonths(i) == DateTime.Now)
                    {
                        months = i;
                        break;
                    }
                    else if (previousDate.AddMonths(i) >= DateTime.Now)
                    {
                        months = i - 1;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Error occured " + ex.Message + "");
            }
            return months;
        }
    }
}
