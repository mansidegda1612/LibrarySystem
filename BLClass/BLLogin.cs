using LibrarySystem.Models;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LibrarySystem.BLClass
{
    /// <summary>
    /// Bl Class for Login
    /// </summary>
    public class BLLogin
    {
        #region Public Members
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(ConnectionString, MySqlDialect.Provider);
        public ObjectCache cache = MemoryCache.Default;
        CacheItemPolicy policy = new CacheItemPolicy();
        #endregion

        #region Private Members
        private string _key = "2B4D625165546857";
        #endregion

        #region Public Methods

        /// <summary>
        /// Login For Librarian
        /// </summary>
        /// <param name="objLoginModel"></param>
        /// <returns></returns>
        public string LoginLibrarian(LoginModel objLoginModel)
        {

            string CipherPassword = Encrypt(objLoginModel.Password);

            using (var db = dbFactory.Open())
            {
                try
                {
                    var ans = db.Select<lib02>(x => x.b02f04 == objLoginModel.Email && x.b02f06 == CipherPassword);

                    if (ans.Count == 1)
                    {
                        var CacheKey = "ValidLibrarian";
                        policy.AbsoluteExpiration = DateTime.Now.AddHours(10);
                        cache.Add(CacheKey, ans, policy);
                        string _token = createToken(objLoginModel.Email, "Librarian");
                        return ( _token);
                    }
                    else
                        return "Fail";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        /// <summary>
        /// Login for user
        /// </summary>
        /// <param name="objLoginModel"></param>
        /// <returns></returns>
        public string LoginUser(LoginModel objLoginModel)
        {

            string CipherPassword = Encrypt(objLoginModel.Password);

            using (var db = dbFactory.Open())
            {
                try
                { 
                    var ans = db.Select<lib03>(x => x.b03f06 ==objLoginModel.Email && x.b03f07 == CipherPassword);
                    if (ans.Count == 1)
                    {
                        var CacheKey = "ValidUser";
                        policy.AbsoluteExpiration = DateTime.Now.AddHours(10);
                        cache.Add(CacheKey, ans, policy);
                        string _token = createToken(objLoginModel.Email,"User");
                        return ( _token);
                    }
                    else
                        return "Fail";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        /// <summary>
        /// SignUp for Librarian
        /// </summary>
        /// <param name="objlib02"></param>
        /// <returns></returns>
        public bool SignUpLibrarian(lib02 objlib02)
        {

            objlib02.b02f06 = Encrypt(objlib02.b02f06);

            using (var db = dbFactory.Open())
            {
                try
                {
                    var id = db.Insert(objlib02);
                    if (id > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        /// <summary>
        /// SignUp for Librarian
        /// </summary>
        /// <param name="objlib02"></param>
        /// <returns></returns>
        public bool SignUpUser(lib03 objlib03)
        {
            objlib03.b03f07 = Encrypt(objlib03.b03f07);
            using (var db = dbFactory.Open())
            {
                try
                {
                    var id = db.Insert(objlib03);
                    if (id > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        #endregion

        #region Private Methods
        private string Encrypt(string password)
        {
            RijndaelManaged objRijndael = new RijndaelManaged();
            var key = Encoding.ASCII.GetBytes(this._key);
            var encryptor = objRijndael.CreateEncryptor(key, key);
            byte[] byteData = Encoding.ASCII.GetBytes(password);
            var data = encryptor.TransformFinalBlock(byteData, 0, byteData.Length);
            return Convert.ToBase64String(data);
        }

        private string createToken(string email,string role)
        {
            // Set issued at date
            DateTime _issuedAt = DateTime.UtcNow;
            // Set the time when it expires
            DateTime _expires = DateTime.UtcNow.AddMinutes(20);

            
            var _tokenHandler = new JwtSecurityTokenHandler();

            // Create an identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,email),
                new Claim(ClaimTypes.Role,role)
            }) ;

            // Our super secret key
            string _sec = ConfigurationManager.AppSettings["Secret"].ToString();
            // Current Time
            var _nbf = DateTime.UtcNow;
            var _securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(_sec));
            var _signingCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Create the jwt
            var _audience = ConfigurationManager.AppSettings["Audience"].ToString();
            var _issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
            var _token = _tokenHandler.CreateJwtSecurityToken(issuer: _issuer, audience: _audience, subject: claimsIdentity,
                issuedAt: _issuedAt, notBefore: _nbf, expires: _expires, signingCredentials: _signingCredentials);
            var _tokenString = _tokenHandler.WriteToken(_token);

            return _tokenString;
        }
        #endregion
    }
}