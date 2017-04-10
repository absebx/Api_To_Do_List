﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Modelo;
using Datos;

namespace Api.Controllers
{
    //habilitar peticiones desde distintos lados
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BoardController : ApiController
    {
        // GET: api/Board
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Board/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Board
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Board/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Board/5
        public void Delete(int id)
        {
        }
    }
}
