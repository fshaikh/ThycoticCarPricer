namespace CarPricer
{
    #region Car
    /// <summary>
    /// Represents car object
    /// </summary>
    public class Car
    {
        public decimal PurchaseValue { get; set; }
        public int AgeInMonths { get; set; }
        public int NumberOfMiles { get; set; }
        public int NumberOfPreviousOwners { get; set; }
        public int NumberOfCollisions { get; set; }
        public decimal FinalValue { get; set; }
    }
    #endregion Car

    #region Price Determinator
    public class PriceDeterminator
    {
        public decimal DetermineCarPrice(Car car)
        {
            // Start with the current value of the car
            car.FinalValue = car.PurchaseValue;

            // Set the link
            PriceDeterminatorBase startLink = SetLink(car);

            // Start the price calculation link
            startLink.CalculatePrice(car);

            return car.FinalValue;
        }

        private PriceDeterminatorBase SetLink(Car car)
        {
            // Set the determinators link
            AgeDeterminator ageDeterminator = new AgeDeterminator();
            MilesDeterminator milesDeterminator = new MilesDeterminator();
            PreviousOwnerDeterminator previousOwnerDeterminator = new PreviousOwnerDeterminator();
            CollisionsDeterminator collisionsDeterminator = new CollisionsDeterminator();

            // then adjust for age, take that result then adjust for miles
            ageDeterminator.SetNextDeterminator(milesDeterminator);
            if (car.NumberOfPreviousOwners == 0)
            {
                // that if previous owner, had a positive effect, then it should be applied AFTER step 4
                milesDeterminator.SetNextDeterminator(collisionsDeterminator);
                collisionsDeterminator.SetNextDeterminator(previousOwnerDeterminator);
            }
            else
            {
                // If a negative effect, then BEFORE step 4.
                milesDeterminator.SetNextDeterminator(previousOwnerDeterminator);
                previousOwnerDeterminator.SetNextDeterminator(collisionsDeterminator);
            }
            return ageDeterminator;
        }
    }
    #endregion Price Determinator
}
