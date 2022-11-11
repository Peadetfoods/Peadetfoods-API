using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PaystackSDK.Exceptions;
using PaystackSDK.Models;
using PaystackSDK.Models.Transactions;

namespace PaystackSDK.Services
{
    internal class Transactions : ITransactions
    {
        private readonly HttpService _httpService;

        public Transactions(HttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Response<PaystackInitializeTransactionResponse>> Initialize(PaystackInitializeTransactionRequest request)
        {
            var result = await _httpService.PostAsync<PaystackInitializeTransactionRequest, PaystackInitializeTransactionResponse>("transaction/initialize", request);
            return result;
        }
    }
}
