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
        //Get: api/boards
        public IEnumerable<Board> getAllBoards()
        {
            return dataBoards.getAll();
        }
        //Todas las notas de un usuario api/user/id
        //Get: api/board/{user_id}
        public IHttpActionResult getBoardByUser(int id)
        {
            //pasar todos los boards en un array
            Board[] boards = dataBoards.getAll();
            //buscar el board seleccionado
            var board = boards.FirstOrDefault((u) => u.User_id == id);
            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }
    }
}
