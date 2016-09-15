using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask
{
    public class Programm
    {

        static void Main(string[] args) {
            using (TestDbContext dbContext = new TestDbContext())
            {
                Console.WriteLine(dbContext.Drivers.Count());
            }
            Console.ReadKey();

        }
    }
}