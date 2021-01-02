using System;
using Portfolio.Core.Interfaces.Services;

namespace Portfolio.Core.ServiceResults
{
    public class EmailServiceResult : IServiceResult<bool>
    {
        public bool Result { get; set; }
        public bool IsSuccess { get; set; }
        public Exception Error { get; set; }
    }
}