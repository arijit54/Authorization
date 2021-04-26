using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Models
{
    public class JWTAuthenticationManager: IJWTAuthenticationManager
    {

        private static List<CustomerDetail> CustomerList = new List<CustomerDetail>()
            {
              new CustomerDetail(){CustomerId=1,CustomerName="Arijit Dutta",Password="arijit@123",PhoneNumber="(660) 663-4518",Email="arijit.dutta@gmail.com" },
              new CustomerDetail(){CustomerId=2,CustomerName="Kishalay Bhowmick",Password="kishalay@123",PhoneNumber="(608) 265-2215",Email="kishalay.bhowmick@gmail.com" },
              new CustomerDetail(){CustomerId=3,CustomerName="Nishan Ghosh",Password="nishan@123",PhoneNumber="(959) 119-8364",Email="nishan.ghosh@gmail.com"},
              new CustomerDetail(){CustomerId=4,CustomerName="Vikas Kumar Thakur",Password="vikas@123",PhoneNumber="(959) 119-8364",Email="vikas.kumar.thakur@gmail.com"},
              new CustomerDetail(){CustomerId=5,CustomerName="Malla Teja Jagannatha Sri Harnath",Password="harnath@123",PhoneNumber="(959) 119-8364",Email="harnath.malla@gmail.com"},

            };

       /* private readonly string Key;
        public JWTAuthenticationManager(string Key)
        {
            this.Key = Key;
        }*/
        public string Authenticate(string email, string password)
        {
            if (!CustomerList.Any(c => c.Email == email && c.Password == password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();// install System.IdentityModel.Tokens.Jwt
            var tokenKey = Encoding.ASCII.GetBytes("This is my jwt authentication demo");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }
                ),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)


            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        public CustomerDetail GetCustomer(string email)
        {
            return CustomerList.FirstOrDefault(x => x.Email == email);
        }
    }
}
