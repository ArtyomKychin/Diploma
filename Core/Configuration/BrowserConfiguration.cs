namespace Core.Configuration
{
    public class BrowserConfiguration : IConfiguration 
    {
        public string SectionName => "Browser";
        public bool Headless { get; set; }
        public string? BrowserType { get; set; }
        public int ImplicityWait { get; set; }
    }
}
