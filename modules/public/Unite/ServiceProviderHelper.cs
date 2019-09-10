using System;
using System.Collections.Generic;
using System.Text;

namespace Unite
{
    public class ServiceProviderHelper
    {
        public static IServiceProvider CurrentProvider { get; private set; }

        public static void Init(IServiceProvider provider)
        {
            CurrentProvider = provider;
        }

    }
}
