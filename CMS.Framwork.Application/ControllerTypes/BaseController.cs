using System;
using System.Net;
using System.Threading.Tasks;
using CMS.Framwork.Data.Framwork;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Framwork.Application.ControllerTypes
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase, IBaseController<T> where T : BaseModel
    {
        public BaseController(Func<T, T> beforCreate = null, Func<T, T> onCreate = null, Func<T, T> afterCreate = null, Func<T, T> beforUpdate = null, Func<T, T> onUpdate = null, Func<T, T> afterUpdate = null, Func<T, T> beforDelete = null, Func<T, T> onDelete = null, Func<T, T> afterDelete = null, Func<string, string> beforGetById = null, Func<string, T> onGetById = null, Func<T, T> afterGetById = null, Func<T, T> beforGetAll = null, Func<T, T> onGetAll = null, Func<T, T> afterGetAll = null)
        {
            BeforCreate = beforCreate;
            OnCreate = onCreate ?? new Func<T, T>(model => throw new NotImplementedException());
            AfterCreate = afterCreate;
            BeforUpdate = beforUpdate;
            OnUpdate = onUpdate ?? new Func<T, T>(model => throw new NotImplementedException());
            AfterUpdate = afterUpdate;
            BeforDelete = beforDelete;
            OnDelete = onDelete ?? new Func<T, T>(model => throw new NotImplementedException());
            AfterDelete = afterDelete;
            BeforGetById = beforGetById;
            OnGetById = onGetById ?? new Func<string, T>(model => throw new NotImplementedException());
            AfterGetById = afterGetById;
            BeforGetAll = beforGetAll;
            OnGetAll = onGetAll ?? new Func<T, T>(model => throw new NotImplementedException());
            AfterGetAll = afterGetAll;
        }

        public Func<T, T> BeforCreate { get; set; }
        public Func<T, T> OnCreate { get; set; }
        public Func<T, T> AfterCreate { get; set; }

        public virtual async Task<ResponseResource<T>> Create(T model)
        {
            HttpStatusCode statusCode = HttpStatusCode.NotImplemented;
            try
            {

                if (model == null) statusCode = HttpStatusCode.NoContent;

                if (BeforCreate != null) model = await Task.Run(() => BeforCreate(model));

                if (model != null && model.Validate())
                {
                    model = await Task.Run(() => OnCreate(model));
                    if (AfterCreate != null) model = await Task.Run(() => AfterCreate(model));
                }
                else
                {
                    statusCode = HttpStatusCode.BadRequest;
                }

                return new ResponseResource<T>(model, statusCode);
            }
            catch (Exception e)
            {
                statusCode = HttpStatusCode.InternalServerError;
                return new ResponseResource<T>(model, statusCode, e);
            }
        }



        public Func<T, T> BeforUpdate { get; set; }
        public Func<T, T> OnUpdate { get; set; }
        public Func<T, T> AfterUpdate { get; set; }
        public async Task<ResponseResource<T>> Update(T model)
        {
            HttpStatusCode statusCode = HttpStatusCode.NotImplemented;
            try
            {

                if (model == null) statusCode = HttpStatusCode.NoContent;

                if (BeforUpdate != null) model = await Task.Run(() => BeforUpdate(model));

                if (model != null && model.Validate())
                {
                    model = await Task.Run(() => OnUpdate(model));
                    if (AfterUpdate != null) model = await Task.Run(() => AfterUpdate(model));
                }
                else
                {
                    statusCode = HttpStatusCode.BadRequest;
                }

                return new ResponseResource<T>(model, statusCode);
            }
            catch (Exception e)
            {
                statusCode = HttpStatusCode.InternalServerError;
                return new ResponseResource<T>(model, statusCode, e);
            }
        }

        public Func<T, T> BeforDelete { get; set; }
        public Func<T, T> OnDelete { get; set; }
        public Func<T, T> AfterDelete { get; set; }
        public async Task<ResponseResource<T>> Delete(T model)
        {
            HttpStatusCode statusCode = HttpStatusCode.NotImplemented;
            try
            {

                if (model == null) statusCode = HttpStatusCode.NoContent;

                if (BeforDelete != null) model = await Task.Run(() => BeforDelete(model));

                if (model != null && model.Validate())
                {
                    model = await Task.Run(() => OnDelete(model));
                    if (AfterDelete != null) model = await Task.Run(() => AfterDelete(model));
                }
                else
                {
                    statusCode = HttpStatusCode.BadRequest;
                }

                return new ResponseResource<T>(model, statusCode);
            }
            catch (Exception e)
            {
                statusCode = HttpStatusCode.InternalServerError;
                return new ResponseResource<T>(model, statusCode, e);
            }
        }
        public Func<string, string> BeforGetById { get; set; }
        public Func<string, T> OnGetById { get; set; }
        public Func<T, T> AfterGetById { get; set; }

        public async Task<ResponseResource<T>> GetById(string Id)
        {
            HttpStatusCode statusCode = HttpStatusCode.NotImplemented;
            T model = null;
            try
            {

                if (string.IsNullOrWhiteSpace(Id)) statusCode = HttpStatusCode.NoContent;

                if (BeforGetById != null) Id = await Task.Run(() => BeforGetById(Id));

                if (string.IsNullOrWhiteSpace(Id))
                {
                    model = await Task.Run(() => OnGetById(Id));
                    if (AfterGetById != null) model = await Task.Run(() => AfterGetById(model));
                    return model != null
                        ? new ResponseResource<T>(model,
                            statusCode)
                        : new ResponseResource<T>(HttpStatusCode.BadRequest,
                            $"no Item was found with an Id or {Id}");
                }
                else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    return new ResponseResource<T>(statusCode,
                        $"no Item was found with an Id or {Id}");
                }
            }
            catch (Exception e)
            {
                statusCode = HttpStatusCode.InternalServerError;
                return new ResponseResource<T>(model, statusCode, e);
            }
        }
        public Func<T, T> BeforGetAll { get; set; }
        public Func<T, PagedResponseResource<T>> OnGetAll { get; set; }
        public Func<PagedResponseResource<T>, PagedResponseResource<T>> AfterGetAll { get; set; }
        public async Task<PagedResponseResource<T>> GetAll()
        {
            HttpStatusCode statusCode = HttpStatusCode.NotImplemented;
            PagedResponseResource<T> result = null;
            try
            {

                //if (BeforGetAll != null) Task.Run(() => BeforGetAll());

                
                    result = await Task.Run(() => OnGetAll(null));
                    if (AfterGetAll != null) result = await Task.Run(() => AfterGetAll(result));
                    return result != null
                        ?result.SetStatusCode(statusCode)
                        : new ResponseResource<T>(HttpStatusCode.BadRequest,
                            $"no Item was found with an Id or {Id}");
                
            }
            catch (Exception e)
            {
                statusCode = HttpStatusCode.InternalServerError;
                return new ResponseResource<T>(model, statusCode, e);
            }
        }

    }
}


