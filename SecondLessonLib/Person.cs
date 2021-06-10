using System;
using System.Collections.Generic;
using System.Text;

namespace SecondLessonLib
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public void CallMethod()
        {
            Console.WriteLine("Some method");
        }
    }
}
