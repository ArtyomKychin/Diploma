using Diploma.Core;
using NUnit.Framework;

namespace Core.Configuration
{
    public class AppConfiguration
    {
        private static BrowserConfiguration browser = null;
        public static BrowserConfiguration? Browser 
        {
            get
            {
                if (browser == null)
                {
                    browser = new BrowserConfiguration();
                    browser.Headless = GetValue<bool>("Headless");
                    browser.ImplicityWait = GetValue<int>("ImplicityWait");
                    browser.BrowserType = GetValue<string>("BrowserType");
                }
                return browser;
            }
        }

        public static T GetValue<T>(string key)
        {
            string value = TestContext.Parameters.Get(key);

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}


