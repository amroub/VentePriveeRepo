using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentePrivee.Model;
using VentePrivee.Repository;

namespace VentePrivee.Service
{
    public class ListService
    {
        public static int GetListCount()
        {
            return DataRepository.Persons.Count();
        }

        public static int GetNumberByGender(int gender)
        {
            return DataRepository.Persons.Where(x => x.Gender == gender).Count();
        }

        public static int GetWomenNumberByCity(string city)
        {
            return DataRepository.Persons.Where(x => x.Gender == 1 && x.City==city).Count();
        }

        public static List<Person> GetPersonByName(string Name)
        {
            return DataRepository.Persons.Where(x => x.Name == Name).ToList();
        }

        public static bool IsNamePresent(string Name)
        {
           int count = DataRepository.Persons.Where(x => x.Name == Name).Count();
            if (count > 0)
                return true;
            return false;
        }
    }
}
