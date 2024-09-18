using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.ServiceResponse;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HotelProject.DataAccessLayer.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));

            if (user == null) //Kayıtlı kullanıcı yoksa bu gelir. 
            {
                response.Success = false;
                response.Message = "Kullanıcı Bulunmadı...";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) //Girilen şifre hash lenen şifreye uymassa bu yapı çalışacak.
            {
                response.Success = false;
                response.Message = "Hatalı Giriş";
            }
            else
            {
                response.Data = CreateToken(user); //Artık oluşturdugumuz token methodu gelecek.
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExists(user.Username))  //Eğer bu satır çalışırsa kullanıcı mevcut UserExists methodu ile çık code dan demek.
            {
                response.Success = true;
                response.Message = "Kullanıcı Mevcut";
                return response;
            }
            CreatePasswordHash(password, out byte[] passwordSalt, out byte[] passwordHash); //CreatePasswordHash adında bir method oluşturduk burada kullandık. CreatePasswordHash sifre oluşturup hash leyecegiz. Methodu. ihtiyac halinde çağırıp kullanacagız.
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            response.Data = user.UserID;

            return response;

        }
        public async Task<bool> UserExists(string username) //Çıkış yapma
        {
            if (await _context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }



        private void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //hashleyecegimiz şifrenin algoritması…
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)//Login oldukatn sonra şifreyi çözme methodu yazdık.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //hashleyecegimiz şifrenin algoritması…
            {
                var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computerHash.SequenceEqual(passwordHash);
            }
        }


        private string CreateToken(User user) //Token oluşturma methodu.
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), //Token bir saat geçerli olacak….
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); //Token oluştu.
        }

    }
}

