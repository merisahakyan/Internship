using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message)
        {
            Console.Write(message);
        }

        public NotFoundException(string message, Exception e) : base(message, e) { }
    }
}
