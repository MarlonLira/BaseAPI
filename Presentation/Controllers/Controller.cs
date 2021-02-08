using Application.Commons;
using Application.Interfaces;
using Application.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Presentation.Controllers
{
    public class Controller<IService> : ApiController
    {
        protected readonly IService _service;

        public Controller(IService service)
        {
            this._service = service;
        }

        public IHttpActionResult Response(Response response)
        {
            return Content(response.HttpCode, response);
        }
    }
}