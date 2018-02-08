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
    public class DataTreeRepository
    {
        private static Object _lock = new object();

        private static Person root = null;

        public static Person Root
        {
            get
            {
                lock (_lock)
                {
                    if (root == null)
                    {
                        root = GetData();
                    }
                    return root;
                }
            }
        }

        public static Person GetData()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\dataTree.json");
            var persons = ParseJsonFile(path);
            var firstNode = new Person() { Name = "Root" };
            firstNode.Children = new List<Person>(persons);
            return firstNode;
        }

        public static List<Person> ParseJsonFile(string path)
        {
            string text = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Person>>(text);
        }

        public static string GetStringFromJson()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\dataTree.json");
            return File.ReadAllText(path).Trim().ToLower();
        }

    }
}
