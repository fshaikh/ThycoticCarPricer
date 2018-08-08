using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPricer
{
    /// <summary>
    /// Previous owner-based Price Determinator
    /// </summary>
    public class PreviousOwnerDeterminator : PriceDeterminatorBase
    {
        #region Private Members
        private const int MIN_PREVIOUS_OWNERS = 2;
        private const decimal REDUCED_PERCENTAGE_VALUE = 25M;
        private const decimal ADDED_PERCENTAGE_VALUE = 10M;
        #endregion Private Members

        /// <summary>
        /// Calculate price based on previous owners criteria
        /// </summary>
        /// <param name="car">Car object whose final price is to be calculated</param>
        public override void CalculatePrice(Car car)
        {
            // If the car has had more than 2 previous owners, reduce its value by (25) percent
            if (car.NumberOfPreviousOwners > MIN_PREVIOUS_OWNERS)
            {
                car.FinalValue = car.FinalValue - ((REDUCED_PERCENTAGE_VALUE * car.FinalValue) / 100);
            }

            // If the car has had no previous  owners, add ten(10) percent of the FINAL car value at the end
            if (car.NumberOfPreviousOwners == 0)
            {
                car.FinalValue += ((ADDED_PERCENTAGE_VALUE * car.FinalValue) / 100);
            }
            // send to next price determinator in the link
            SendToNextDeterminator(car);
        }
    }
}
