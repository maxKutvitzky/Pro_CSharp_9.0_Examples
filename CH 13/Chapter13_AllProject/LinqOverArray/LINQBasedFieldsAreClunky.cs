using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    internal class LINQBasedFieldsAreClunky
    {
        private static string[] currentVideoGames =
        {
            "Morrowind", 
            "Uncharted 2",  
            "Fallout 3", 
            "Daxter", 
            "System Shock 2"
        };
        // Can't use implicit typing here! Must know type of subset!
        private IEnumerable<string> subset =
        from g in currentVideoGames
        where g.Contains(" ")
        orderby g
        select g;
        public void PrintGames()
        {
            foreach (var item in subset)
            {
                Console.WriteLine(item);
            }
        }
    }
}
