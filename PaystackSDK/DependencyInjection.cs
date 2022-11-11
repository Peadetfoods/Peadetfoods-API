using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using PaystackSDK.Services;

namespace PaystackSDK
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPaystackSdk(this IServiceCollection services, string secretKey)
        {
            services.AddScoped<IPaystackClient, PaystackClient>();
            services.AddHttpClient<HttpService>(options =>
            {
                options.BaseAddress = new Uri("https://api.paystack.co/");
                options.DefaultRequestHeaders.Add("Authorization", $"Bearer {secretKey}");
            });

            return services;
        }
    }
}
