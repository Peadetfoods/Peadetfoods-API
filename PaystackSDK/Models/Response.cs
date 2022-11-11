using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaystackSDK.Models
{
    public class Response<TData>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
    }
}
