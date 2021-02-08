using Application.Commons;
using Application.Interfaces;
using Application.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("v1/partner")]
    public class PartnerController : Controller<IPartnerService>
    {
        public PartnerController(IPartnerService service) : base(service) { }

        // GET: api/Partner/5
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Response(await this._service.GetById(id));
        }

        [HttpPost]
        [Route("")]
        // POST: api/Partner
        public async Task<IHttpActionResult> Post([FromBody] PartnerViewModel model)
        {
            return Response(await this._service.Save(model));
        }

        [Authorize]
        [HttpPut]
        [Route("")]
        // PUT: api/Partner/5
        public async Task<IHttpActionResult> Put([FromBody] PartnerViewModel model)
        {
            return Response(await this._service.Update(model));
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        // DELETE: api/Partner/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Response(await this._service.Delete(id));
        }
    }
}
