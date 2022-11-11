using PaystackSDK.Services;

namespace PaystackSDK
{
    public interface IPaystackClient
    {
        ITransactions Transactions { get; }
    }
}
