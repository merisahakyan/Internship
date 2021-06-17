using Lesson3.Exceptions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            //tea
            //omelet
            //toast
            //put omelet on toast

            //tea + toast + omelet
            //omelet + toast, tea

            //File I/O
            //FileInfo  , FileStream, StreamWriter, StreamReader, File
            using (var streamReader = new StreamReader(@"C:\Users\wwwme\OneDrive\Desktop\FileData.txt"))
            {
                var text = streamReader.ReadToEnd();
                var person = JsonConvert.DeserializeObject<Person>(text);
                Console.WriteLine(person.Age > 18);
                //streamReader.Close();
                //streamReader.Dispose();
            }

            using (var streamWriter = new StreamWriter(@"C:\Users\wwwme\OneDrive\Desktop\FileData.txt"))
            {
                var person = new Person
                {
                    Age = 222,
                    LastName = "Petrosyan",
                    Name = "Petros"
                };
                var text = JsonConvert.SerializeObject(person);
                streamWriter.WriteLine(text);

            }

            //Exceptions

            try
            {
                //var person = GetPerson(1);
                //if(person == null)
                //{
                //    throw new NotFoundException($"Person you're looking for is not found with given id : {1}");
                //}
            }
            catch (ThirthException e)
            {

            }
            catch (SecondException e)
            {

            }
            catch (NotFoundException e)
            {

            }
            catch (Exception e)
            {

            }
            finally { }







            Console.ReadLine();
        }

        public int GetIntAsync()
        {
            return 0;
        }


        public void PrintInt()
        {
            var intValueTask =  GetInt();

            Console.Write("");
            Console.Write("");
            Console.Write("");
            Console.Write("");
            Console.Write("");
            Console.Write("");

            var intValue = intValueTask.GetAwaiter().GetResult();
            Console.Write(intValue);
        }


        public async Task<int> GetInt()
        {
            await CallPrintMessageAsync();
            return 1;
        }

        public async Task CallPrintMessageAsync()
        {
            var message = "Hi";
            await PrintMessageAsync(message);

            Console.Write("");
            Console.Write("");
            Console.Write("");
            Console.Write("");
            Console.Write("");
            Console.Write("");
        }

        public async Task PrintMessageAsync(string message)
        {

        }
    }
}
