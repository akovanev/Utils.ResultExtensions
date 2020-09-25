# Utils.ResultExtensions

Helps to response with the expected status code. Requires .NET 5.

## Author's blog

[Single Status Codes Strategy](https://akovanev.com/blogs/2020/09/09/how-to-sanitize-sensitive-data)

## Usage

```
public Result<IEnumerable<WeatherForecast>> GetForecastCollection()
{
    var collection = _weatherProvider.GetForecastCollection();

    var result = new Result<IEnumerable<WeatherForecast>>();

    if (collection is not null)
    {
        result.Data = collection;
    }
    else
    {
        result.Error = new Error { Type = ErrorType.ServiceFail, Message = "Fail" };
    }

    return result;
}


[HttpGet]
public ActionResult Get()
{
    var result = _foreCastService.GetForecastCollection();
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

