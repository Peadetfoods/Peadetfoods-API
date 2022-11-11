using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Peadetfoods.Infrastructure.Common
{
    public struct Result<T>
    {
        public Result(T data)
        {
            Data = data;
            Error = null;
            Succeeded = true;
        }

        public Result(Error error)
        {
            Data = default(T);
            Error = error;
            Succeeded = false;
        }

        public T? Data { get; set; }
        public Error? Error { get; set; }
        public bool Succeeded { get; set; }

        public static implicit operator Result<T>(T data) => new Result<T>(data);
        public static implicit operator Result<T>(Error error) => new Result<T>(error);
    }
}
