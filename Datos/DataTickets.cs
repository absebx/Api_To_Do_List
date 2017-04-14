using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Diagnostics;
namespace Datos
{
    public class DataTickets
    {
        public Ticket[] getAllTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            using (var db = new ToDoListContext())
            {
                var query = from u in db.TICKET
                            orderby u.id ascending
                            select u;
                foreach (var item in query)
                {
                    Ticket ticket = new Ticket();
                    ticket.Id = item.id;
                    ticket.Title = item.title;
                    ticket.Description = item.description;
                    ticket.Date = item.date;
                    ticket.EstimatedTime = item.estimated_time;
                    ticket.BoardID = item.board_id;
                    tickets.Add(ticket);
                }
                return tickets.ToArray();
            }
        }

        public long addTicket(Ticket ticket)
        {
            long id=0;
            using (var db = new ToDoListContext())
            {
                var newTicket = new TICKET
                {
                    title = ticket.Title,
                    description = ticket.Description,
                    date = ticket.Date,
                    estimated_time = ticket.EstimatedTime,
                    board_id = ticket.BoardID
                };

                db.TICKET.Add(newTicket);
                db.SaveChanges();

                id = newTicket.id;
            }
            return id;
        }

        public CompleteTicket[] getCompleteTickets()
        {
            List<CompleteTicket> tickets = new List<CompleteTicket>();
            using (var db = new ToDoListContext())
            {
                var query = from t in db.TICKET
                            join rel in db.REL_TICKET_HAS_STATUS on t.id equals rel.id_ticket
                            join stat in db.STATUS on rel.id_status equals stat.id
                            select t;
                foreach (var item in query)
                {
                    CompleteTicket complete = new CompleteTicket();
                    complete.Id = item.id;
                    complete.Title = item.title;
                    complete.Description = item.description;
                    complete.Date = item.date;
                    complete.EstimatedTime = item.estimated_time;
                    complete.BoardID = item.board_id;
                    complete.StatusName = item.REL_TICKET_HAS_STATUS.First().STATUS.name;
                    complete.ColorStatus = item.REL_TICKET_HAS_STATUS.First().STATUS.color;
                    tickets.Add(complete);
                }

                return tickets.ToArray();
            }
        }

        //eliminar ticket
        public void deleteTicket(int id)
        {
            using (var db = new ToDoListContext())
            {
                var ticket = db.TICKET.Where(t => t.id == id).First();
                db.TICKET.Remove(ticket);
                db.SaveChanges();
            }
        }
    }
}
