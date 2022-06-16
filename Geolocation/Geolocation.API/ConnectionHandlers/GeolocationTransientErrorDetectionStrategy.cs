using Microsoft.Rest.TransientFaultHandling;
using System.Net;

namespace Geolocation.Api.ConnectionHandlers
{
    public class GeolocationTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception ex)
        {
            return CheckIsTransient(ex);
        }

        private static bool CheckIsTransient(Exception ex)
        {
            if (ex is TimeoutException)
            {
                return true;
            }
            else if (ex is WebException)
            {
                return true;
            }
            else if (ex is UnauthorizedAccessException)
            {
                return false;
            }

            return false;
        }
    }
}
