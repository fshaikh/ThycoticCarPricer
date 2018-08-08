using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPricer
{
    /// <summary>
    /// Base class for all Price Determinators
    /// </summary>
    public abstract class PriceDeterminatorBase
    {
        #region Members
        /// <summary>
        /// Next Price Determinator in the link
        /// </summary>
        protected PriceDeterminatorBase _nextPriceDeterminator;
        #endregion Members

        #region Abstract Methods
        /// <summary>
        /// Calculates the final price of the car based on the rules for each price determinator
        /// </summary>
        /// <param name="car">Car object whose final price is to be calculated</param>
        public abstract void CalculatePrice(Car car);
        #endregion Abstract Methods

        #region Public Methods
        /// <summary>
        /// Sets the next determinator in the link
        /// </summary>
        /// <param name="priceDeterminator"></param>
        public void SetNextDeterminator(PriceDeterminatorBase priceDeterminator)
        {
            this._nextPriceDeterminator = priceDeterminator;
        }
        #endregion Public Methods


        #region Protected Methods
        /// <summary>
        /// Invoke the next determinator in the link
        /// </summary>
        /// <param name="car"></param>
        protected void SendToNextDeterminator(Car car)
        {
            // send to next determinator
            if (_nextPriceDeterminator != null)
            {
                _nextPriceDeterminator.CalculatePrice(car);
            }
        }
        #endregion Protected Methods
    }
}
