using Newtonsoft.Json;

namespace AspnetCore.WebAPI.Dtos
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public Error() {}

        public Error(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}