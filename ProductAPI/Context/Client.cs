using System.Collections.Generic;

namespace ProductApi.Context
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ReservedProduct> ReservedProducts { get; set; }
    }
}