using System.ComponentModel.DataAnnotations;

namespace MenuLog.Web.ViewModels
{
    public class RestaurantModel
    {
        public string Name { get; set; }
        
        public string SuburbName { get; set; }
        public string PostCode { get; set; }

        public int? Rating { get; set; }

        [DisplayFormat(DataFormatString = "{0:00}")]
        public double Score { get; set; }
    }
}
