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
using System.Diagnostics;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TicketsController : ApiController
    {
        //obtener controlador de datos para ticket
        DataTickets dataTickets = new DataTickets();
        //obtener controlador de datos para relaciones
        DataTicketHasStatus dataRelations= new DataTicketHasStatus();
        //get: api/tickets
        public IEnumerable<Ticket> getAllTickets()
        {
            return dataTickets.getAllTickets();
        }
        /*obtener todos los tickets de un board
        get: api/tickets/{id_board}*/
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

        /*post una nueva tarjeta
        post: api/tickets*/
        [HttpPost]
        public IHttpActionResult postTicket(Ticket ticket)
        {
            //ingresar nuevo ticket y obtener id
            long newTicketId = dataTickets.addTicket(ticket);
            
            //corroborar ingresado
            if (newTicketId != 0)
            {
                //ingresar nueva relacion, para dejar ticket como pendiente
                RelTicketHasStatus relation= new RelTicketHasStatus();
                relation.idStatus = 1; //1=> pendiente
                relation.IdTicket = newTicketId;
                relation.Date = ticket.Date;
                //ingresar relacion y corroborar que se ingresa correctamente
                if (dataRelations.addRelation(relation) != 0)
                {
                    return Ok(ticket);
                }
            }
            return NotFound();
        }

    }
}
