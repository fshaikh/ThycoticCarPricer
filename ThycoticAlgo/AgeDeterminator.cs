using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPricer
{
    /// <summary>
    /// Age-based Price Determinator
    /// </summary>
    public class AgeDeterminator : PriceDeterminatorBase
    {
        #region Private Members
        const int MAX_AGE_LIMIT = 120;
        const decimal REDUCED_PERCENTAGE_VALUE = 0.5M;
        #endregion Private Members

        /// <summary>
        /// Calculate price based on age criteria
        /// </summary>
        /// <param name="car">Car object whose final price is to be calculated</param>
        public override void CalculatePrice(Car car)
        {
            // Calculate the price
            car.FinalValue = car.FinalValue - GetReducedAgeValue(car);
            // send to next price determinator in the link
            SendToNextDeterminator(car);
        }

        /// <summary>
        ///  Given the number of months of how old the car is, reduce its value one-half (0.5) percent.
        /// </summary>
        /// <param name="car"></param>
        /// <returns>Reduced value</returns>
        private decimal GetReducedAgeValue(Car car)
        {
            // After 10 years, it's value cannot be reduced further by age
            int ageInMonths = car.AgeInMonths > MAX_AGE_LIMIT ? MAX_AGE_LIMIT : car.AgeInMonths;
            // Given the number of months of how old the car is, reduce its value one-half (0.5) percent.
            return ((decimal)ageInMonths * REDUCED_PERCENTAGE_VALUE * car.FinalValue) / 100;
        }
    }
}
