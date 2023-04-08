using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        IGenericRepository<Tourist> touristRepository { get; set; }
        IJwtProvider jwtProvider { get; set; }

        public AuthenticationService(IGenericRepository<Tourist> touristRepository, IJwtProvider jwtProvider)
        {
            this.touristRepository=touristRepository;
            this.jwtProvider=jwtProvider;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public string Login(string username, string password)
        {
            var user = touristRepository.Find(t => t.UsernameName == username).FirstOrDefault();
            
            if (user == null)
            {
                return string.Empty;//should i return specific response?
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return string.Empty;//should i return specific response?
            }
            string token = jwtProvider.CreateToken(user);
            return token;
        }
    }
}
