using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PaystackSDK.Services;

namespace PaystackSDK
{
    internal class PaystackClient : IPaystackClient
    {
        public PaystackClient(HttpService httpService)
        {
            Transactions = new Transactions(httpService);
        }

        public ITransactions Transactions { get; }
    }
}
