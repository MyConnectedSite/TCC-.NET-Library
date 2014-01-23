using System;

namespace TCC2.API
{
    public interface IRequest : IAsyncResult
    {
        void SetDataProvider(IRequestDataProvider dataProvider);
        void BeginGetResponse(AsyncCallback callback, object state);
        IResponse EndGetResponse();
        void Abort();

        int Timeout { get; set; }
    }
}