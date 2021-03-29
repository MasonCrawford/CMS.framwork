using System;
using System.Net;
using Newtonsoft.Json;

namespace CMS.Framwork.Data.Framwork
{
    public class BaseResponseResource<T>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public BaseResponseResource(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (data != null)
            {
                Data = data;
                StatusCode = statusCode;
            }
            else
            {
                SetErrorMessage(new ArgumentNullException(nameof(data)));
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public BaseResponseResource(HttpStatusCode statusCode, string errorMessage)
        {
            ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
            StatusCode = statusCode;
        }

        public BaseResponseResource(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string errorMessage = null)
        {
            Data = data;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public BaseResponseResource(T data, HttpStatusCode statusCode, Exception exception)
        {
            Data = data;
            StatusCode = statusCode;
            SetErrorMessage(exception);
        }

        [JsonProperty(
            NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; private set; }

        public bool IsError => !String.IsNullOrWhiteSpace(ErrorMessage);

        public T Data { get; private set; }
        public HttpStatusCode StatusCode { get; set; }
        public BaseResponseResource<T> SetErrorMessage(Exception exception)
        {
            ErrorMessage = $"{exception.TargetSite}: {exception.Message}";
            return this;
        }
        public BaseResponseResource<T> SetStatusCode(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            return this;
        }

    }
}
