using System;
using CommonSnappableTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSnapIn
{
    [CompanyInfo(CompanyName = "FooBar", CompanyUrl = "www.FooBar.com")]
    public class CSharpModule : IAppFunctionality
    {
        public void DoIt()
        {
            Console.WriteLine("You have just used the C# snap-in!");
        }
    }
}
