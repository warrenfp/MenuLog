namespace MenuLog.Core.Interfaces
{
    public interface IRestaurant
    {
        string Name { get; set; }
        ISuburb Suburb { get; set; }
        int? Rating { get; set; }
        double Score { get; set; }
    }
}
