using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModels
{
    public class DBUser
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long? PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
