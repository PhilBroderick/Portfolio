using System;

namespace Portfolio.Core.Interfaces.Services
{
    public interface IServiceResult<T>
    {
        T Result { get; set; }
        bool IsSuccess { get; set; }
        Exception Error { get; set; }
    }
}