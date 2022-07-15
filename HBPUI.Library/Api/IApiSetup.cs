using System.Net.Http;

namespace HBPUI.Library.Api
{
    public interface IApiSetup
    {
        HttpClient Client { get; }

        string GetApiUri(string uriName);
    }
}