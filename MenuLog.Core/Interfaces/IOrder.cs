using System;

namespace MenuLog.Core.Interfaces
{
    public interface IOrder
    {
        DateTime OrderDate { get; set; }
        double Price { get; set; } //Keeping it simple for this demo. Ignoring any GST considerations
    }
}