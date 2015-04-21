using System;

namespace DotNetUtils.DotNetFrameworkContrib
{
    public class NullDisposable : IDisposable
    {
        public static NullDisposable New
        {
            get { return new NullDisposable(); }
        }

        public void Dispose()
        {

        }
    }
}