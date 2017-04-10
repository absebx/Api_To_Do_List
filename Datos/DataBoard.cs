using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Datos
{
    public class DataBoard
    {
        public Board[] getAll()
        {
            List<Board> boards = new List<Board>();
            using (var db = new ToDoListContext())
            {
                var query = from u in db.BOARD
                            orderby u.id ascending
                            select u;

                foreach (var item in query)
                {
                    Board board = new Board();
                    board.Id = item.id;
                    board.Name = item.name;
                    board.User_id = (long)item.user_id;
                    boards.Add(board);
                }

            }
            return boards.ToArray();
        }
    }
}
