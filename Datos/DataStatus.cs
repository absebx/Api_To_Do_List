using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//extras
using Modelo;


namespace Datos
{
    public class DataStatus
    {
        public Status[] getAllStatus()
        {
            List<Status> allStatus = new List<Status>();
            using (var db = new ToDoListContext())
            {
                var query = from s in db.STATUS
                            orderby s.id ascending
                            select s;
                foreach(var item in query)
                {
                    Status status = new Status();
                    status.Id = item.id;
                    status.Name = item.name;
                    status.Color = item.color;
                    //agregar status recien creado a la lista
                    allStatus.Add(status);
                }
                return allStatus.ToArray();
            }
        }
    }
}
