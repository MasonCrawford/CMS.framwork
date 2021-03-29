using System.Threading.Tasks;

namespace CMS.Framwork.Data.Framwork
{
    public interface IBaseModel
    {
        /// <summary>
        /// the unique identifier
        /// </summary>
        string Id { get; set; }

        Task CanDelete { get; }

        bool Validate();
    }
}