using Azure.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace CQRSApplication.Helpers
{
    public class HttpContextHelper
    {
        private readonly IHttpContextAccessor _httpCtx;
        //IhttpContextAccessor gives request, which constits of authorization token
        //Service is registered to access this
        public HttpContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpCtx = httpContextAccessor;
        }
        public Guid ReturnUserId()
        {
            var httpContext = _httpCtx.HttpContext;

            // Access HttpContext and perform operations
            string authHeader = httpContext.Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            if (authHeader.StartsWith("Bearer"))
            {
                authHeader = authHeader.Replace("Bearer ", "");
            }
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == "UserId").Value;
            if (id == null)
            {
                throw new Exception("Cant find the userId from the token, or Invalid token");
            }
            return new Guid(id);
        }
    }
}
