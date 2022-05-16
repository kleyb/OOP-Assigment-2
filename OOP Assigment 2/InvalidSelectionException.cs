using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //This exception is used to throw an error when the user enters a value not in the menu
    class InvalidSelectionException : Exception
    {
    public InvalidSelectionException() { }
    //it prints a message to the user when called
    public InvalidSelectionException(string message) : base(message) { }
    }

