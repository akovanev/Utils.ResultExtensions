namespace Akov.Utils.ResultExtensions
{
    public interface IStatusCodeHelper
    {
        int GetStatusCode<T>(RestType restType, Result<T> result);
    }
}
