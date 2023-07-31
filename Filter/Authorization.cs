using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LibrarySystem.Filter 
{
    public class Authorization : AuthorizationFilterAttribute
    {
        
        #region Public Methods
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string _token;
            if (SkipAuthorization(actionContext)) return;
            if (!TryRetrieveToken(actionContext, out _token))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }


            try
            {
                // Our super secret key
                string _sec = ConfigurationManager.AppSettings["Secret"].ToString();
                var _now = DateTime.UtcNow;
                var _securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(_sec));

                // Validation logic
                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidAudience = ConfigurationManager.AppSettings["Audience"].ToString(),
                    ValidateIssuer = true,
                    ValidIssuer = ConfigurationManager.AppSettings["Issuer"].ToString(),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _securityKey,
                    LifetimeValidator = LifetimeValidator
                };

                // Extract and assign the user of the jwt
                Thread.CurrentPrincipal = handler.ValidateToken(_token, validationParameters, out securityToken);
                HttpContext.Current.User = handler.ValidateToken(_token, validationParameters, out securityToken);
                return;
            }
            // If validation fails
            catch (SecurityTokenValidationException)
            {
            }
            // Other errros
            catch (Exception)
            {
            }

            return;
        }

        /// <summary>
        /// Check if the life time of token is still valid
        /// </summary>
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Retrieves token from the request headers
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="token">The token : if exists</param>
        private static bool TryRetrieveToken(HttpActionContext actionContext, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!actionContext.Request.Headers.TryGetValues("apiKey", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }

            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken;
            return true;
        }


        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
        #endregion
    }

}