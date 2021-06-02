using System;

namespace HttpClientSample
{
    class HttpClientException : Exception
    {
        public HttpClientException()
        {

        }

        public HttpClientException(string data)
            : base(String.Format("{0}", data))
        {

        }
    }
}
