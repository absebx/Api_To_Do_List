using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//nuestros usings
using System.Web.Http.Cors;
using Modelo;
using Datos;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BoardsController : ApiController
    {
        DataBoard dataBoards = new DataBoard();

        //obtener todos los usuarios
        //Get: api/users
        public IEnumerable<Board> getAllUsers()
        {
            return dataBoards.getAll();
        }
        //Todas las notas de un usuario api/user/id
        //Get: api/user/{id}
        public IHttpActionResult getBoard(int id)
        {
            //pasar todos los usuarios en un array
            Board[] boards = dataBoards.getAll();
            //buscar el usuario seleccionado
            var board = boards.FirstOrDefault((u) => u.Id == id);
            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }
    }
}
