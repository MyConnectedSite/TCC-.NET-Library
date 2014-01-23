using System;

namespace TCC2.API
{
    public interface IApiCallResult
    {
        void Validate(IRequestDataProvider provider);
    }
}
