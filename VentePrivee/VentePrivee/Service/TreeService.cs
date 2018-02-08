using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentePrivee.Model;
using VentePrivee.Repository;

namespace VentePrivee.Service
{
    public class TreeService
    {
        static int depth = 0;
        static int womenNumber = 0;
        static int menNumber = 0;

        public static int GetTreeDepth()
        {  
            return findLevel(DataTreeRepository.Root);  
        }

        public static int GetNumber(int gender)
        {
            if (gender == 0)
                return findMenNumber(DataTreeRepository.Root);
            else
                return findWomenNumber(DataTreeRepository.Root);
        }

        public static int GetWomenCountWithoutRecur()
        {
           string data = DataTreeRepository.GetStringFromJson();
           return data.Count((x) => x == '1');
        }

        private static int findLevel(Person parentNode)
        {
            depth++;
           
            foreach(Person subNode in parentNode.Children)
            {
                if(subNode.Children!=null)
                findLevel(subNode);
            }

            return depth;
        }

        private static int findMenNumber(Person parentNode)
        {
            foreach (Person subNode in parentNode.Children)
            {
                if (subNode.Gender == 0)
                    menNumber++;

                if (subNode.Children != null)
                    findMenNumber(subNode);
            }

            return menNumber;
        }

        private static int findWomenNumber(Person parentNode)
        {
            foreach (Person subNode in parentNode.Children)
            {
                if (subNode.Gender == 1)
                    womenNumber++;

                if (subNode.Children != null)
                    findWomenNumber(subNode);
            }

            return womenNumber;
        }



    }
}
