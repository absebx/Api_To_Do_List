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
        //obtener todos los usuarios en un arreglo de usuarios del modelo
        public Usuario[] getAll()
        {
            //crear lista de usuarios
            List<Usuario> usuarios = new List<Usuario>();
            using (var db = new ToDoListContext())
            {
                var query = from u in db.USER
                            orderby u.id ascending
                            select u;
                //ingresar resultados de la query en la lista como objetos usuario
                foreach (var item in query)
                {
                    Usuario usuario = new Usuario();
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
