﻿using System;
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
    }
}
