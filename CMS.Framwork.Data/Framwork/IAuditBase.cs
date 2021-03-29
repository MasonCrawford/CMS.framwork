using System;
using System.Threading.Tasks;

namespace CMS.Framwork.Data.Framwork
{
    public interface IAuditBase
    {
        /// <summary>
        /// The User Id of the user who created the entity.
        /// </summary>
        string CreatedByUserId { get; set; }

        /// <summary>
        /// The Date and Time the entity was first created.
        /// </summary>
        DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// The User Id of the user who last modified the entity.
        /// </summary>
        string ModifiedByUserId { get; set; }

        /// <summary>
        /// The Date and Time the entity was last modified.
        /// </summary>
        DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// the unique identifier
        /// </summary>
        string Id { get; set; }

        Task CanDelete { get; }

        bool Validate();
    }
}