using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VentePrivee.Model;
using VentePrivee.Service;

namespace VentePrivee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** List ****");

            Console.WriteLine(ListService.GetListCount());
            Console.WriteLine(ListService.GetNumberByGender(1));
            Console.WriteLine(ListService.GetNumberByGender(0));
            Console.WriteLine(ListService.GetWomenNumberByCity("Marseille"));

            var result = ListService.GetPersonByName("Eden");
            foreach (var item in result)
            {
                Console.WriteLine(String.Format("({0},{1},{2})",item.Name,item.City,item.Gender));
            }
            
            Console.WriteLine(ListService.IsNamePresent("Claude"));


            Console.WriteLine("**** Tree ****");

            int depth = TreeService.GetTreeDepth();
            int mensCount = TreeService.GetNumber(0);
            int womensCount = TreeService.GetNumber(1);
            int womensCountWithoutRecur = TreeService.GetWomenCountWithoutRecur();


            Console.WriteLine("Depth : "+depth);
            Console.WriteLine("Men Count : "+ mensCount);
            Console.WriteLine("Women Count : "+ womensCount);
            Console.WriteLine("Women Count without recur: " + womensCountWithoutRecur);


            Console.ReadLine();
        }       
    }
}
