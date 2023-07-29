namespace SeleniumTests.Diploma
{
    public class UserLoginModel
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public override string? ToString()
        {
            return $"Mail: {Mail} Password:{Password}";
        }
    }
}