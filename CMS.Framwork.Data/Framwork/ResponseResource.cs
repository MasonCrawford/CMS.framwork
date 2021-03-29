using System;
using System.Net;

namespace CMS.Framwork.Data.Framwork
{
    public class ResponseResource<T> : BaseResponseResource<T> where T : BaseModel
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public ResponseResource(T data, HttpStatusCode statusCode = HttpStatusCode.OK) : base(data,
            statusCode)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public ResponseResource(HttpStatusCode statusCode, string errorMessage) : base(statusCode,
            errorMessage)
        {
        }

        public ResponseResource(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string errorMessage = null) : base(data,
            statusCode,
            errorMessage)
        {
        }

        public ResponseResource(T data, HttpStatusCode statusCode, Exception exception) : base(data,
            statusCode,
            exception)
        {
        }
    }
}
