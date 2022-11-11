using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace PaystackSDK.Models.Transactions
{
    public class PaystackInitializeTransactionRequest
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        public void SetAmount(decimal amount)
        {
            const int NAIRA_TO_KOBO_RATE = 100;
            var amountInKobo = amount * NAIRA_TO_KOBO_RATE;

            Amount = amount.ToString("n0");
        }
    }
}
