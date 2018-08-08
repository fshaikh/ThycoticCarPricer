using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPricer
{
    /// <summary>
    /// Collisions-based Price Determinator
    /// </summary>
    public class CollisionsDeterminator : PriceDeterminatorBase
    {
        #region Private Members
        private const int MAX_COLLISIONS = 5;
        private const decimal REDUCED_PERCENTAGE_VALUE = 2M;
        #endregion Private Members

        /// <summary>
        /// Calculate price based on collisions criteria
        /// </summary>
        /// <param name="car">Car object whose final price is to be calculated</param>
        public override void CalculatePrice(Car car)
        {
            car.FinalValue = car.FinalValue - GetCollisionsReducedValue(car);
            // send to next price determinator in the link
            SendToNextDeterminator(car);
        }

        /// <summary>
        /// For every reported collision the car has been in, remove two (2) percent of it's value up to five (5) collisions.
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        private decimal GetCollisionsReducedValue(Car car)
        {
            int numberOfCollisions = car.NumberOfCollisions > MAX_COLLISIONS ? MAX_COLLISIONS : car.NumberOfCollisions;
            return (numberOfCollisions * 2 * car.FinalValue) / 100;
        }
    }
}
