using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FirstClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //stack, queue, list, arraylist, linkedlist, tree, dictionary, hash table ...
            string[] strArr = new string[30];

            //object obj ;
            //obj = "string"

            //obj
            //var x = (string) obj
            ArrayList arrList = new ArrayList();
            arrList.Add("string");
            arrList.Add(4);
            arrList.Add(5.6);

            //Queue
            //FIFO

            //
            List<string> strList = new List<string>(30); //30*2 = 60   60*2=120
            //new string[30]  1 2 3 4 ..15  16. 30
            //add 30 members
            // add 31st
            // new string[60]
            //copy all members from old array to new one
            strList.First(c => c == "test");

            //linkedlist
            LinkedList<int> lnkList = new LinkedList<int>();
            lnkList.AddFirst(1);

            //{ current = 1, next =null, last = obj1 }
            //lnkList.Add(2);
            //obj1 - { value = 1, next =->objMid, last = obj2 }
            //objMiid - { value = 1, next =->obj2, last = obj2 }
            //bbj2 - { value = 2, next =null, last = obj2 }

            //Dictionary
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "one");



            //var a1 = new A();
            //a1.Value = 1;
            //var a2 = new A();
            //a2.Value = 1;

            //Console.WriteLine(a1 == a2);

            int value = 15;
            value.PrintValue();


            var newList = strList.Select(c => new
            {
                PhoneNumber = c, //c.PhoneNumber
                Email = c, // c.Email,
                FullName = c + c // c.Firstname + c.LastName
            });

        }

    }

    //class A
    //{
    //    public int Value { get; set; }

    //    public static bool operator == (A a1,A a2){
    //        return true;
    //    }
    //}

    public static class ExtensionClass
    {
        public static void PrintValue(this int i)
        {
            Console.WriteLine(i);
        }
    }
}
