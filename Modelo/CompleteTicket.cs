using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CompleteTicket
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int EstimatedTime { get; set; }
        public long BoardID { get; set; }
        public string StatusName { get; set; }
        public string ColorStatus { get; set; }
    }
}
