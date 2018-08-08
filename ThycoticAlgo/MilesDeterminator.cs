using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPricer
{
    /// <summary>
    /// Miles-based Price Determinator
    /// </summary>
    public class MilesDeterminator : PriceDeterminatorBase
    {
        #region Private Members
        private const int MILES_STEP = 1000;
        private const int MAX_MILES = 150000;
        private const decimal REDUCED_PERCENTAGE_VALUE = 0.2M;
        #endregion Private Members

        /// <summary>
        /// Calculate price based on miles criteria
        /// </summary>
        /// <param name="car">Car object whose final price is to be calculated</param>
        public override void CalculatePrice(Car car)
        {
            // For every 1,000 miles on the car, reduce its value by one-fifth of a percent(0.2). Do not consider remaining miles
            car.FinalValue = car.FinalValue - GetMilesReducedValue(car);
            // send to next price determinator in the link
            SendToNextDeterminator(car);
        }

        private decimal GetMilesReducedValue(Car car)
        {
            // After 150,000 miles, it's value cannot be reduced further by miles.
            int numberOfMiles = (car.NumberOfMiles > MAX_MILES) ? MAX_MILES : car.NumberOfMiles;
            return ((numberOfMiles / MILES_STEP) * REDUCED_PERCENTAGE_VALUE * car.FinalValue) / 100;
        }
    }
}
