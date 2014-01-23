using System;

namespace TCC2.API
{
    public interface IUploader
    {
        event EventHandler<ProgressEventArgs> UploadProgressChanged;
    }
}