namespace Entity.Models.Person
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public int StateProvinceID { get; set; }
        public string PostalCode { get; set; }
    }
}