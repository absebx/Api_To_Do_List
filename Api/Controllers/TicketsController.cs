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

        //obtener todos los tickets completos
        //get: api/tickets
        public IEnumerable<CompleteTicket> getAllTickets()
        {
            return dataTickets.getCompleteTickets();
        }

        /*Obtener tickets completos por id
         get: api/tickets/{id_ticket}*/
        public IHttpActionResult getTicket(int id)
        {
            CompleteTicket[] tickets = dataTickets.getCompleteTickets();
            var ticket = tickets.FirstOrDefault((t) => t.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        /*obtener todos los tickets completos de un board
        get: api/tickets/byBoard/{id_board}*/
        [HttpGet]
        [Route("api/tickets/byboard/{id}")]
        public IHttpActionResult getTicketByBoard(int id)
        {
            //pasar todos los tickets en un array
            CompleteTicket[] tickets = dataTickets.getCompleteTickets();
            //buscar los tickets en el board
            var ticket = tickets.Where((t) => t.BoardID == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }


        /*post un nuevo ticket->
         * un nuevo ticket no necesita estar completo
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



        //eliminar un ticket
        //delete: api/tickets/{id}
        public void deleteTicket(int id)
        {
            //eliminar relacion primero
            dataRelations.delteByTicketId(id);
            //eliminar ticket
            dataTickets.deleteTicket(id);
        }

        //modificar ticket
        //put: api/ticket/{id}
        public void updateTicket(int id, CompleteTicket ticket)
        {
            dataTickets.updateTicket(ticket);
        }

    }
}
