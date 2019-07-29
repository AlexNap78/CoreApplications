using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCisalfa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ApiCisalfa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public ResponseResultModel Get(string username, string pwd)
        {
            Log.Information("CreateUser : " + username);

            var response = new ResponseResultModel();
            var outcome = new OutcomeModel();

            using (var db = new DBMAGTSTContext())
            {
                var u = db.DtOperatori.Where(x => x.OperMail.ToLower() == username.ToLower() && x.OperPwd.ToLower() == pwd.ToLower()).FirstOrDefault();

                if(u != null)
                {
                    outcome.isSuccess = true;
                    outcome.description = "User logged";
                    response.outcome = outcome;
                    response.result = u;
                }
                else
                {
                    outcome.isSuccess = false;
                    outcome.description = "Unauthorized user.";
                    response.outcome = outcome;
                }
            }

            return response;
        }
    }
}