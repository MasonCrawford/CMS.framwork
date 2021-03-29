using System;
using System.Collections.Generic;
using System.Net;

namespace CMS.Framwork.Data.Framwork
{
    public class PagedResponseResource<T> : BaseResponseResource<List<T>>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public PagedResponseResource(List<T> data, HttpStatusCode statusCode = HttpStatusCode.OK) : base(data,
            statusCode)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public PagedResponseResource(HttpStatusCode statusCode, string errorMessage) : base(statusCode,
            errorMessage)
        {
            TotalRecords = 0;
            Records = new List<T>();
        }

        public PagedResponseResource(List<T> data, HttpStatusCode statusCode = HttpStatusCode.OK, string errorMessage = null) : base(data,
            statusCode,
            errorMessage)
        {
        }

        public PagedResponseResource(List<T> data, HttpStatusCode statusCode, Exception exception) : base(data,
            statusCode,
            exception)
        {
        }

        /// <summary>
        /// The total number of records that exist in the database before paging
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// The paged list of records
        /// </summary>
        public virtual List<T> Records { get; set; }

        /// <summary>
        /// Sets the list of paged records and updates the TotalRecords
        /// </summary>
        /// <param name="totalRecords"></param>
        /// <param name="pagedRecords"></param>
        public void SetRecords(List<T> pagedRecords, int totalRecords)
        {
            TotalRecords = totalRecords;
            Records = pagedRecords;
        }



    }
}
