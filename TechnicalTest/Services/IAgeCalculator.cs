using TechnicalTest.Models;

namespace TechnicalTest.Services
{
    public interface IAgeCalculator
    {
        DetailsModel CalculateAge(DateTime? dateofBirth);
    }
}
