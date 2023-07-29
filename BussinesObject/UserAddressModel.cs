namespace SeleniumTests.Diploma
{
    public class UserAddressModel

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string MobilePhone { get; set; }
        public string AddressAlias { get; set; }

        public override string? ToString()
        {
            return
                $"Mail: {FirstName}" +
                $"LastName: {LastName}" +
                $"PostalCode: {PostalCode}" +
                $"Address: {Address}" +
                $"City: {City}" +
                $"MobilePhone: {MobilePhone}" + 
                $"AddressAlias: {AddressAlias}";
        }
    }
}