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
            List<User> usuarios = new List<User>();
            using (var db = new ToDoListContext())
            {
                var query = from u in db.USER
                            orderby u.id ascending
                            select u;
                //ingresar resultados de la query en la lista como objetos usuario
                foreach (var item in query)
                {
                    User usuario = new User();
                    usuario.Id = item.id;
                    usuario.Name = item.name;
                    usuarios.Add(usuario);
                }
                //se retorna la lista en formato de array
                return usuarios.ToArray();
            }
        }
    }
}
