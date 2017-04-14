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
    public class TicketStatusController : ApiController
    {
        DataTicketHasStatus dataRelation = new DataTicketHasStatus();
        /*obtener todas las relaciones
        get:api/ticketstatus*/
        public IEnumerable<RelTicketHasStatus> getAllRelations()
        {
            return dataRelation.getAll();
        }

        //obtener relacion por id
        //get: api/ticketstatus/{id}
        public IHttpActionResult getRelation(int id)
        {
            //pasar todos las relaciones en un array
            RelTicketHasStatus[] relations = dataRelation.getAll();
            //buscar las relacion con el id
            var relation = relations.FirstOrDefault((r) => r.Id == id);
            if (relation == null)
            {
                return NotFound();
            }
            return Ok(relation);
        }

        //obtener la relacion que pertenesca a un ticket
        //get: api/ticketstatus/byticket/{id_ticket}
        [HttpGet]
        [Route("api/ticketstatus/byticket/{id}")]
        public IHttpActionResult getRelationByTicket(int id)
        {
            //pasar todos las relaciones en un array
            RelTicketHasStatus[] relations = dataRelation.getAll();
            //buscar las relacion con el ticket
            var relation = relations.FirstOrDefault((r) => r.IdTicket == id);
            if (relation == null)
            {
                return NotFound();
            }
            return Ok(relation);
        }

        //modificar relacion
        //put: api/ticketstatus/{id_relation}
        public void putRelation(int id, RelTicketHasStatus relation)
        {
            dataRelation.updateRelation(relation);
        }
    }
}
