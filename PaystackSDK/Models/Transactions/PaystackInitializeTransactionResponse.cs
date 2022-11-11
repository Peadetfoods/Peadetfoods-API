using Newtonsoft.Json;

namespace PaystackSDK.Models.Transactions
{
    public class PaystackInitializeTransactionResponse
    {
        [JsonProperty("authorization_url")]
        public string AuthorizationUrl { get; set; }

        [JsonProperty("access_code")]
        public string AccessCode { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
