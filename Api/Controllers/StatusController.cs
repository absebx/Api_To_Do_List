using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//extras
using System.Web.Http.Cors;
using Modelo;
using Datos;
namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StatusController : ApiController
    {
        //obtener controlador de datos para Status
        DataStatus dataStatus = new DataStatus();

        //get: api/get/status
        public IEnumerable<Status> getAllStatus()
        {
            return dataStatus.getAllStatus();
        }

        //get api/get/status/{id_status}
        public IHttpActionResult getStatusById(int id)
        {
            Status[] allStatus = dataStatus.getAllStatus();
            var status = allStatus.FirstOrDefault((s) => s.Id == id);
            if(status == null)
            {
                return NotFound();
            }
            return Ok(status);

        }
    }
}
