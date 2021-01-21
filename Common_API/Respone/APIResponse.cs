using Common_API.ResponseHeader;

namespace Common_API.Respone
{
    public class APIResponse<T> : APIResponseHeader
    {
        public APIResponse(string status = null, string message = null, T responeBody = default)
        {
            this.Status = status;
            this.ResponseBody = responeBody;
        }

        public T ResponseBody { get; set; }
    }
}
