using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaystackSDK.Exceptions
{
    public class PaystackRequestException : Exception
    {
        public PaystackRequestException(string? message) : base(message)
        {
        }

        public static async Task Throw(HttpResponseMessage message)
        {
            var content = await message.Content.ReadAsStringAsync();
            throw new PaystackRequestException(content);
        }
    }
}
