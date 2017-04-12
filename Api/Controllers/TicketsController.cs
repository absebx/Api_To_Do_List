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
    public class TicketsController : ApiController
    {
        DataTickets dataTickets = new DataTickets();

        //get: api/tickets
        public IEnumerable<Ticket> getAllTickets()
        {
            return dataTickets.getAllTickets();
        }
        //obtener todos los tickets de un board
        //get: api/tickets/{id_board}
        public IHttpActionResult getTicketByBoard(int id)
        {
            //pasar todos los tickets en un array
            Ticket[] tickets = dataTickets.getAllTickets();
            //buscar los tickets en el board
            var ticket = tickets.Where((t) => t.BoardID == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        //post una nueva tarjeta
        //post: api/tickets
        [HttpPost]
        public Ticket postTicket(Ticket ticket)
        {
            dataTickets.addTicket(ticket);
            return ticket;
        }

    }
}
