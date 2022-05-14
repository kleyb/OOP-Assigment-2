using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class InvalidSelectionException : Exception
    {
    public InvalidSelectionException() { }
    public InvalidSelectionException(string message) : base(message) { }
    }

