using Application.Commons;
using Application.Interfaces;
using Application.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("v1/user")]
    public class UserController : Controller<IUserService>
    {
        public UserController(IUserService service) : base(service) { }

        // GET: v1/User/client/1
        [Authorize]
        [HttpGet]
        [Route("client/{id}")]
        public async Task<IHttpActionResult> GetByClientId(int id)
        {
            return Response(await this._service.GetByClientId(id));
        }

        // GET: v1/User/5
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Response(await this._service.GetById(id));
        }

        // POST: v1/User
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] UserViewModel model)
        {
            return Response(await this._service.Save(model));
        }

        // POST: v1/User
        [HttpPost]
        [Route("signin")]
        public async Task<IHttpActionResult> SignIn([FromBody] UserViewModel model)
        {
            return Response(await this._service.SignIn(model));
        }

        // PUT: v1/User
        [Authorize]
        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Put([FromBody] UserViewModel model)
        {
            return Response(await this._service.Update(model));
        }

        // DELETE: v1/User
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Response(await this._service.Delete(id));
        }
    }
}
