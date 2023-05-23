using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inter.people.central.Domain.Exceptions
{
    public class GradeRankException : Exception
    {
        public GradeRankException(string errorMessage) : base(errorMessage)
        {

        }
    }
}



