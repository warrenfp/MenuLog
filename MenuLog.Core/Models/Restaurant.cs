
using MenuLog.Core.Interfaces;

namespace MenuLog.Core.Models
{
    public class Restaurant : IRestaurant
    {
        public string Name { get; set; }
        public ISuburb Suburb { get; set; }

        /// <summary>
        /// The current rating as an integer, 1-5 stars. This will be recalculated regularaly
        /// </summary>
        public int? Rating { get; set; }
        public double Score { get; set; }
    }
}
