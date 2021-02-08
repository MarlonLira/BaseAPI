using Application.Commons;
using Application.Interfaces;
using Application.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("v1/client")]
    public class ClientController : Controller<IClientService>
    {
        public ClientController(IClientService service) : base(service) { }

        // GET: api/Client/5
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Response(await this._service.GetById(id));
        }

        [HttpPost]
        [Route("")]
        // POST: api/Client
        public async Task<IHttpActionResult> Post([FromBody] ClientViewModel model)
        {
            return Response(await this._service.Save(model));
        }

        [Authorize]
        [HttpPut]
        [Route("")]
        // PUT: api/Client/5
        public async Task<IHttpActionResult> Put([FromBody] ClientViewModel model)
        {
            return Response(await this._service.Update(model));
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        // DELETE: api/Client/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Response(await this._service.Delete(id));
        }
    }
}
