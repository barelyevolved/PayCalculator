using System.Collections.Generic;

namespace PayCalculation.Domain.Interfaces
{
    public interface IEmployee
    {
        int Reference { get; set; }

        List<IPayElement> PayElements { get; }
    }
}
