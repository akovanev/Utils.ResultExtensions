# Utils.ResultExtensions

Helps to response with the expected status code. Requires .NET 5.

Usage

```
[HttpGet]
public ActionResult Get()
{
    var collection = GetForecastCollection();

    var result = new Result<IEnumerable<WeatherForecast>>();

    if (collection is not null)
    {
        result.Data = collection;
    }
    else
    {
        result.Error = new Error { Type = ErrorType.DatabaseFail, Message = "Fail" };
    }

    return GetActionResult(RestType.Get, result);
}

protected ActionResult GetActionResult<T>(RestType restType, Result<T> result)
{
    if (result is null) return new EmptyResult();

    int code = result.GetStatusCode(restType);
    object data = result.IsValid ? result.Data : result.Error.Message;
    return new JsonResult(data) { StatusCode = code };
}
```

