using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Akov.Utils.ResultExtensions
{
    public class StatusCodeHelper : IStatusCodeHelper
    {
        protected virtual Dictionary<string, int> FailXxxCodes { get; } = new Dictionary<string, int>
        {
            {ErrorType.ConfigurationFail, StatusCodes.Status500InternalServerError},
            {ErrorType.AuthenticationFail, StatusCodes.Status401Unauthorized},
            {ErrorType.AuthorizationFail, StatusCodes.Status403Forbidden},
            {ErrorType.ValidationFail, StatusCodes.Status400BadRequest},
            {ErrorType.DatabaseFail, StatusCodes.Status503ServiceUnavailable},
            {ErrorType.ServiceFail, StatusCodes.Status503ServiceUnavailable},
            {ErrorType.LogicalFail,  StatusCodes.Status400BadRequest},
            {ErrorType.ResourceNotFound,  StatusCodes.Status404NotFound},
        };

        public int GetStatusCode<T>(RestType restType, Result<T> result)
        {
            if (!result.IsValid) return GetFailStatusCode(result.Error.Type);

            return restType switch
            {
                RestType.Get or RestType.Delete or RestType.Options => StatusCodes.Status200OK,
                RestType.Post => StatusCodes.Status201Created,
                _ => result.Data is not null
                    ? StatusCodes.Status200OK
                    : StatusCodes.Status204NoContent,
            };
        }

        protected virtual int GetFailStatusCode(string errorType)
        {
            return errorType is not null && FailXxxCodes.ContainsKey(errorType)
                ? FailXxxCodes[errorType]
                : StatusCodes.Status500InternalServerError;
        }
    }
}
