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

        //api/ticketstatus
        public IEnumerable<RelTicketHasStatus> getAllRelations()
        {
            return dataRelation.getAll();
        }

        //api/ticketstatus/{id_ticket}
        public IHttpActionResult getTicketByBoard(int id)
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
    }
}
