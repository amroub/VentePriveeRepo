using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentePrivee.Model
{
    public class Person
    {       
        public string Name { get; set; }
        public string City { get; set; }
        public int Gender { get; set; }
        public List<Person> Children { get; set; }
    }
}
