using Application.Commons;
using Application.Interfaces;
using Application.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("v1/user-affiliation")]
    public class UserAffiliationController : Controller<IUserAffiliationService>
    {
        public UserAffiliationController(IUserAffiliationService service) : base(service) { }

        // GET: v1/UserAffiliation/5
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Response(await this._service.GetById(id));
        }

        // POST: v1/UserAffiliation
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] UserAffiliationViewModel model)
        {
            return Response(await this._service.Save(model));
        }

        // PUT: v1/UserAffiliation
        [HttpPut]
        [Route("accept")]
        public async Task<IHttpActionResult> Accept([FromBody] UserAffiliationViewModel model)
        {
            return Response(await this._service.Accept(model));
        }

        // DELETE: v1/UserAffiliation
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Response(await this._service.Delete(id));
        }
    }
}
