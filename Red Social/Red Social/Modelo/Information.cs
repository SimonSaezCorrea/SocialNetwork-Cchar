using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public abstract class Information
    {
        public string Id { get; set; } // Es el id
        public User Author { get; set; } // Es el creador
        public DateTime Date { get; set; } // Es la fecha de creacion
        public string Content { get; set; } // Es el contenido
        public List<Comment> ListComment { get; set; } // Es una lista de comentarios
        public int Like { get; set; } // La cantidad de likes
        public List<Like> ListLike { get; set; } // Una lista de likes

        /**
         * Constructor
         * @param id El id
         * @param author El creador
         * @param date La fecha de creacion
         * @param content El contenido
         */
        public Information(string Id, User Author, DateTime Date, string Content)
        {
            this.Id = Id;
            this.Author = Author;
            this.Date = Date;
            this.Content = Content;
            ListComment = new List<Comment>();
            Like = 0;
            ListLike = new List<Like>();
        }
        public Information()
        {

        }


        /**
         * Metodo que permite añadir un comentario a la lista de comentarios de la clase
         * @param comment El comentario a añadir
         */
        public void AddListComment(Comment comment)
        {
            ListComment.Add(comment);
        }

        /**
         * Metodo que permite añadir un like a la lista de likes de la clase
         * @param like El like a añadir a la lista de likes
         */
        public void AddListLike(Like like)
        {
            Like += 1;
            ListLike.Add(like);
        }

        public string CreatIdLike()
        {
            return Convert.ToString(ListLike.Count + 1);
        }
    }
}
