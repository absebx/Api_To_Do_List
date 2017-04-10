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
    public class TicketsController : ApiController
    {
        DataTickets dataTickets = new DataTickets();

        //get: api/tickets
        public IEnumerable<Ticket> getAllTickets()
        {
            return dataTickets.getAllTickets();
        }
        //get: api/tickets/{id_board}
        public IHttpActionResult getTicketByBoard(int id)
        {
            //pasar todos los usuarios en un array
            Ticket[] tickets = dataTickets.getAllTickets();
            //buscar el usuario seleccionado
            var ticket = tickets.Where((t) => t.BoardID == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }
    }
}
