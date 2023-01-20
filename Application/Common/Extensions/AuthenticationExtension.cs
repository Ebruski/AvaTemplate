using System.Security.Claims;
using System.Security.Principal;

namespace Application.Common.Extensions
{
    public static class AuthenticationExtension
    {

        public static string GetCustomerUserId(this IIdentity identity)
        {
            return GetClaimValue(identity, "Id");
        }

        public static string GetEmail(this IIdentity identity)
        {
            return GetClaimValue(identity, ClaimTypes.Email);
        }
        public static string GetUsername(this IIdentity identity)
        {
            return GetClaimValue(identity, "userName");
        }
        public static string GetAuthenticationStamp(this IIdentity identity)
        {
            return GetClaimValue(identity, "AuthStamp");
        }
        public static bool IsDeviceRegistered(this IIdentity identity)
        {
            var response = GetClaimValue(identity, "deviceRegistered");
            return bool.Parse(response);
        }
        public static long GetClientId(this IIdentity identity)
        {
            return long.Parse(GetClaimValue(identity, ClaimTypes.NameIdentifier));
        }
        public static string GetUserId(this IIdentity identity)
        {
            return GetClaimValue(identity, ClaimTypes.NameIdentifier);
        }

        private static string GetClaimValue(this IEnumerable<Claim> claims, string claimType)
        {
            var claimsList = new List<Claim>(claims);
            var claim = claimsList.Find(c => c.Type == claimType);
            return claim != null ? claim.Value : null;
        }

        private static string GetClaimValue(IIdentity identity, string claimType)
        {
            var claimIdentity = (ClaimsIdentity)identity;
            return claimIdentity.Claims.GetClaimValue(claimType);
        }
    }
}
