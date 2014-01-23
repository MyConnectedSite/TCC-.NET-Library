using System;
using System.IO;
using System.Net;
using System.Text;

namespace TCC2.API
{
    public interface IResponse
    {
        bool IsError { get; }
        Stream Data { get; }
        WebHeaderCollection Headers { get; }

        Encoding GetDataEncoding();
    }
}