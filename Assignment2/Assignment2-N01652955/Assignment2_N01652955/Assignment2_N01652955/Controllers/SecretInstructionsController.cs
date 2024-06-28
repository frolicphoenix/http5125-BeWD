using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_N01652955.Controllers
{
    public class SecretInstructionsController : ApiController
    {
        [HttpGet]
        [Route("/api/J3/Codes")]
        public string instructionCodes()
        {
            int instructionCode = "57234\r\n00907\r\n34100\r\n99999";
            return instructionCode;
        }

    }
}
