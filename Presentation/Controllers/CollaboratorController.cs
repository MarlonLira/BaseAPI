using Application.Commons;
using Application.Interfaces;
using Application.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Presentation.Controllers
{
    [RoutePrefix("v1/collaborator")]
    public class CollaboratorController : Controller<ICollaboratorService>
    {
        public CollaboratorController(ICollaboratorService service) : base(service) { }

        // GET: v1/Collaborator/client/1
        [Authorize]
        [HttpGet]
        [Route("client/{id}")]
        public async Task<IHttpActionResult> GetByClientId(int id)
        {
            return Response(await this._service.GetByClientId(id));
        }

        // GET: v1/Collaborator/5
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Response(await this._service.GetById(id));
        }

        // POST: v1/Collaborator
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] CollaboratorViewModel model)
        {
            return Response(await this._service.Save(model));
        }

        // POST: v1/Collaborator
        [HttpPost]
        [Route("signin")]
        public async Task<IHttpActionResult> SignIn([FromBody] CollaboratorViewModel model)
        {
            return Response(await this._service.SignIn(model));
        }

        // PUT: v1/Collaborator
        [Authorize]
        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Put([FromBody] CollaboratorViewModel model)
        {
            return Response(await this._service.Update(model));
        }

        // DELETE: v1/Collaborator
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Response(await this._service.Delete(id));
        }
    }
}
