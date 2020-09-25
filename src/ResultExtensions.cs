using System;

namespace Akov.Utils.ResultExtensions
{
    public static class ResultExtensions
    {
        public static int GetStatusCode<T>(this Result<T> result, RestType restType, IStatusCodeHelper statusCodeHelper = null)
        {
            if (result is null) throw new ArgumentNullException(nameof(result));

            statusCodeHelper ??= new StatusCodeHelper();

            return statusCodeHelper.GetStatusCode(restType, result);
        }
    }
}
