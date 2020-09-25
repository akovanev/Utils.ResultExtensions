using System;

namespace Akov.Utils.ResultExtensions
{
    [Flags]
    public enum RestType
    {
        Get = 0x1,
        Post = 0x2,
        Put = 0x4,
        Patch = 0x8,
        Delete = 0x10,
        Options = 0x20,
    }
}
