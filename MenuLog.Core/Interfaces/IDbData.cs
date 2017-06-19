using System.Collections.Generic;

namespace MenuLog.Core.Interfaces
{
    public interface IDbData
    {
        IList<IOrder> OrderData { get; }
    }
}
