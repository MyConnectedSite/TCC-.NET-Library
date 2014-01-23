using System;
using System.Collections.Generic;
using System.IO;

namespace TCC2.API
{
    public interface IRequestDataProvider
    {
        IEnumerable<ApiParameter> Parameters { get; }
        IEnumerable<BinaryAttachment> Attachments { get; }
        string Url { get; }
    }
}