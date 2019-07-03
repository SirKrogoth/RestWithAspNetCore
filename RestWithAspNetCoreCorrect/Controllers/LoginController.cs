using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNetCore.Model;
using RestWithAspNetCore.Business;
using RestWithAspNetCore.Data.VO;
using Tapioca.HATEOAS;
using RestWithAspNetCoreCorrect.Business;
using RestWithAspNetCoreCorrect.Model;
using Microsoft.AspNetCore.Authorization;

namespace RestWithAspNetCore.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    //[ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }        

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]User user)
        {
            if (user == null) return BadRequest();
            return _loginBusiness.FindByLogin(user);
        }
    }
}
