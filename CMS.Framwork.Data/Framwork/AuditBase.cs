using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Framwork.Data.Framwork
{
    public class AuditBase : BaseModel, IAuditBase
    {
        /// <summary>
        /// The User Id of the user who created the entity.
        /// </summary>
        [MaxLength(128)]
        [Required]
        public string CreatedByUserId { get; set; }

        /// <summary>
        /// The Date and Time the entity was first created.
        /// </summary>
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// The User Id of the user who last modified the entity.
        /// </summary>
        [MaxLength(128)]
        public string ModifiedByUserId { get; set; }

        /// <summary>
        /// The Date and Time the entity was last modified.
        /// </summary>
        public DateTime? ModifiedDateTime { get; set; }
    }


}
