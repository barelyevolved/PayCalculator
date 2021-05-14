using System.Collections.Generic;

namespace PayCalculation
{
    public class Employee
    {
        public int Reference { get; set; }

        public List<PayElement> PayElements { get; } = new List<PayElement>();
    }
}
