using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CMS.Framwork.Data.Framwork
{
    /// <summary>
    /// Base Class that Ech Model must inherit from 
    /// </summary>
    public class BaseModel : IBaseModel
    {
        /// <summary>
        /// the unique identifier
        /// </summary>
        [Required]
        [Key]
        public string Id { get; set; }

        public bool Validate()
        {
            return true;
        }

        public virtual Task CanDelete => Task.FromResult(true);

    }
}
