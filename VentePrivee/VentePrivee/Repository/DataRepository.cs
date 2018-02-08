using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VentePrivee.Model;

namespace VentePrivee.Repository
{
    public class DataRepository
    {
        private static Object _lock = new object();

        private static List<Person> persons = null;       

        public static List<Person> Persons
        {
            get
            {
                lock (_lock)
                {
                    if (persons == null)
                    {
                        persons = GetData();
                    }
                    return persons;
                }
            }
        }

        private static List<Person> GetData()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\data.json");
            return ParseJsonFile(path);
        }

        public static List<Person> ParseJsonFile(string path)
        {
            string text = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Person>>(text);
        }
    }
}
