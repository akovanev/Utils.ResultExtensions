using System;

namespace Akov.Utils.ResultExtensions
{
    public class Result<T>
    {
        public T Data { get; set; }
        public Error Error { get; set; }
        public Exception Exception { get; set; }
        public bool IsValid => Error is null;
    }
}
