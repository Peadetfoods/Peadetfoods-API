using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PaystackSDK.Models;
using PaystackSDK.Models.Transactions;

namespace PaystackSDK.Services
{
    public interface ITransactions
    {
        Task<Response<PaystackInitializeTransactionResponse>> Initialize(PaystackInitializeTransactionRequest request);
    }
}
