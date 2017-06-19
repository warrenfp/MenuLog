using System.Collections.Generic;
using MenuLog.Core.Interfaces;

namespace MenuLog.Web.ViewModels
{
    public class RankingModel
    {
        public IEnumerable<RestaurantModel> Rankings { get; set; }
    }
}
