using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Datos
{
    public class DataUsuarios
    {
        //obtener todos los usuarios en un arreglo de users del modelo
        public User[] getAll()
        {
            //crear lista de users del modelo
            List<User> users = new List<User>();
            using (var db = new ToDoListContext())
            {
                var query = from u in db.USER
                            orderby u.id ascending
                            select u;
                //ingresar resultados de la query en la lista como objetos usuario
                foreach (var item in query)
                {
                    User user = new User();
                    user.Id = item.id;
                    user.Name = item.name;
                    users.Add(user);
                }
                //se retorna la lista en formato de array
                return users.ToArray();
            }
        }
    }
}
