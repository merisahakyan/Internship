using SecondLessonLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            //dynamic types
            //object o;
            //dynamic dyn;
            //int i;

            //o = 5;
            //o = "str";
            //o= new List<int>();

            //dyn = new List<int>();
            //dyn = 5;
            //dyn = "str";


            ////o.FuncMeri();

            //dyn = new DynamicFunctions();
            //dyn.CallMethod();

            //dyn = 5;
            //dyn.CallMethod();


            //LINQ
            var persons = new List<Person> { new Person
            {
                Age = 10,
                Name="Meri",
                Address = "xxx"
            },
            new Person
            {
                Age = 11,
                Name="Vahram",
                Address = "xxx"
            },
            new Person
            {
                Age = 30,
                Name="Gevorg",
                Address = "xxx"
            },
            new Person
            {
                Age = 11,
                Name="Emma",
                Address = "xxx"
            },
            new Person
            {
                Age = 70,
                Name="Meri22",
                Address = "xxx"
            },
            new Person
            {
                Age = 100,
                Name="Eeee",
                Address = "xxx"
            }};

            // Func Action
            var personsBefore18 = persons.Where(p => p.Age > 18);
            var personsBefore18List = persons.Where(p => p.Age > 18).ToList();

            //100.000 persons
            //50.000 filtered persons
            //50.000*100.000 avelord gorcoxutyun
            foreach (var item in personsBefore18)
            {
                Console.WriteLine(item.Name);
            }

        }
    }

    
}
