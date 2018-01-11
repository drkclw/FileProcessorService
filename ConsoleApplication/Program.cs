using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IRecordService, ConsoleRecordService>(new HierarchicalLifetimeManager());
            var fileProcessor = container.Resolve<IRecordService>();

            Run(fileProcessor);                
        }
        
        public static void Run(IRecordService recordService)
        {
            string option = "";

            IEnumerable<Record> records = recordService.ImportRecords();

            while (option != "x")
            {
                Console.WriteLine("Please select your output type:");
                Console.WriteLine("1.- Sorted by gender and last name (ascending)");
                Console.WriteLine("2.- Sorted by birth date (ascending)");
                Console.WriteLine("3.- Sorted by last name (descending)");
                Console.WriteLine("x.- Exit app");
                Console.WriteLine();

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("RECORDS SORTED BY GENDER AND LAST NAME:");
                        Console.WriteLine();
                        recordService.OutputRecords("Gender, LastName", records);                        
                        break;
                    case "2":
                        Console.WriteLine("RECORDS SORTED BY DATE OF BIRTH:");
                        Console.WriteLine();
                        recordService.OutputRecords("DateOfBirth", records);                        
                        break;
                    case "3":
                        Console.WriteLine("RECORDS SORTED BY LAST NAME (DESCENDING):");
                        Console.WriteLine();
                        recordService.OutputRecords("LastName", records, true);                       
                        break;
                    case "x":
                        Console.WriteLine("Exiting the app...");
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
            }
        }       
        
    }
}
