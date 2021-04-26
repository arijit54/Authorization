using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Models
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
        CustomerDetail GetCustomer(string email);
    }
}
