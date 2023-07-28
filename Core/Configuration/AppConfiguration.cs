using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public class AppConfiguration
    {
        public static BrowserConfiguration Browser;

        

        public string Headless = TestContext.Parameters.Get("Headless");
        //public string ImplicityWait = TestContext.Parameters.Get("ImplicityWait");
        //public string BrowserType = TestContext.Parameters.Get("BrowserType");
    }

}

