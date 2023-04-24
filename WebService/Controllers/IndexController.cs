using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class IndexController : ApiController
    {
        [ActionName("Sumar")]
        [HttpGet]

        public int Sumar(int id)
        {
            return id + id;
        }

        [ActionName("resta")]
        [HttpPost]

        public int resta(Argumento obj)
        {
            return obj.Operando1 - obj.Operando2;
        }
    }

    public class Argumento
    {
        public int Operando1 { get; set; }
        public int Operando2 { get; set; }
    }
}
