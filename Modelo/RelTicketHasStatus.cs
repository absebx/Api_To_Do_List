using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RelTicketHasStatus
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long IdTicket { get; set; }
        public long idStatus { get; set; }
    }
}
