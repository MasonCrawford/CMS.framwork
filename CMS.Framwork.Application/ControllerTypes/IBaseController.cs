using System;
using System.Threading.Tasks;
using CMS.Framwork.Data.Framwork;

namespace CMS.Framwork.Application.ControllerTypes
{
    public interface IBaseController<T> where T : BaseModel
    {
        Func<T, T> BeforCreate { get; set; }
        Func<T, T> OnCreate { get; set; }
        Func<T, T> AfterCreate { get; set; }
        Func<T, T> BeforUpdate { get; set; }
        Func<T, T> OnUpdate { get; set; }
        Func<T, T> AfterUpdate { get; set; }
        Func<T, T> BeforDelete { get; set; }
        Func<T, T> OnDelete { get; set; }
        Func<T, T> AfterDelete { get; set; }
        Func<string, string> BeforGetById { get; set; }
        Func<string, T> OnGetById { get; set; }
        Func<T, T> AfterGetById { get; set; }
        Func<T, T> BeforGetAll { get; set; }
        Func<T, PagedResponseResource<T>> OnGetAll { get; set; }
        Func<PagedResponseResource<T>, PagedResponseResource<T>> AfterGetAll { get; set; }
        Task<ResponseResource<T>> Create(T model);
        Task<ResponseResource<T>> Update(T model);
        Task<ResponseResource<T>> Delete(T model);
        Task<ResponseResource<T>> GetById(string Id);
        Task<PagedResponseResource<T>> GetAll();
    }
}