using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessUtilsMvc.Services.Exceptions
{
    public class IntegrityException:ApplicationException
    {
        // construtor
        public IntegrityException(string message):base(message)
        {
        }

    }
}
