using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Modelo;
using Datos;

namespace Api.Controllers
{
    //habilitar peticiones desde distintos lados
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        //instancia de Datausers en datos, los obtiene por entity
        DataUsuarios dataUsers = new DataUsuarios();

        //obtener todos los usuarios api/users
        //get api/users
        public IEnumerable<User> getAllUsers()
        {
            return dataUsers.getAll();
        }
        //Todas las notas de un usuario api/user/id
        //get api/user/id
        public IHttpActionResult getUser(int id)
        {
            //pasar todos los usuarios en un array
            User[] users = dataUsers.getAll();
            var user = users.FirstOrDefault((u) => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
