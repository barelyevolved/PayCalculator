using System.Collections.Generic;
using PayCalculation.Domain.Interfaces;

namespace PayCalculation
{
    public class Employee : IEmployee
    {
        public int Reference { get; set; }

        public List<IPayElement> PayElements { get; } = new List<IPayElement>();
    }
}
