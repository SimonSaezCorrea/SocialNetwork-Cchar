using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public abstract class Information
    {
        private int id; // Es el id
        private User author; // Es el creador
        private DateTime date; // Es la fecha de creacion
        private string content; // Es el contenido
        private List<Comment> listComment; // Es una lista de comentarios
        private int like; // La cantidad de likes
        private List<Like> listLike; // Una lista de likes

        /**
         * Constructor
         * @param id El id
         * @param author El creador
         * @param date La fecha de creacion
         * @param content El contenido
         */
        public Information(int id, User author, DateTime date, string content)
        {
            this.id = id;
            this.author = author;
            this.date = date;
            this.content = content;
            listComment = new List<Comment>();
            like = 0;
            listLike = new List<Like>();
        }
        /*
        public int Id
        {
            set { this.id = value}

            get { return id; }
        }

        */


        /**
         * Metodo que permite recoger el id de la clase
         * @return El id de la clase
         */
        public int GetId()
        {
            return id;
        }
        /**
         * Metodo que permite cambiar el id de la clase
         * @param id El id a cambiar
         */
        public void SetId(int id)
        {
            this.id = id;
        }

        /**
         * Metodo que permite recoger el autor de la clase
         * @return El autor de la clase
         */
        public User GetAuthor()
        {
            return author;
        }
        /**
         * Metodo que permite cambiar el autor de la clase
         * @param author El autor a cambiar
         */
        public void SetAuthor(User author)
        {
            this.author = author;
        }

        /**
         * Metodo que permite recoger la fecha de creacion de la clase
         * @return La fecha de creacion
         */
        public DateTime GetDate()
        {
            return date;
        }
        /**
         * Metodo que permite cambiar la fecha de creacion de la clase
         * @param date La fecha a cambiar
         */
        public void SetDate(DateTime date)
        {
            this.date = date;
        }

        /**
         * Metodo que permite recoger el contenido de la clase
         * @return El contenido
         */
        public string GetContent()
        {
            return content;
        }
        /**
         * Metodo que permite cambiar el contenido de la clase
         * @param content El contenido a cambiar
         */
        public void SetContent(string content)
        {
            this.content = content;
        }

        /**
         * Metodo que permite recoger la lista de comentarios de la clase
         * @return La lista de comentarios
         */
        public List<Comment> GetListComment()
        {
            return listComment;
        }
        /**
         * Metodo que permite cambiar la lista de comentarios de la clase
         * @param listComment La lista de comentario a cambiar
         */
        public void SetListComment(List<Comment> listComment)
        {
            this.listComment = listComment;
        }
        /**
         * Metodo que permite añadir un comentario a la lista de comentarios de la clase
         * @param comment El comentario a añadir
         */
        public void AddListComment(Comment comment)
        {
            listComment.Add(comment);
        }

        /**
         * Metodo que permite recoger la cantidad de likes que hay en la clase
         * @return La cantidad de likes
         */
        public int GetLike()
        {
            return like;
        }
        /**
         * Metodos que permite cambiar la cantidad de likes de la clase
         * @param like La cantidad de like a cambiar
         */
        public void SetLike(int like)
        {
            this.like = like;
        }

        /**
         * Metodo que permite recoger la lista de likes de la clase
         * @return La lista de likes
         */
        public List<Like> GetListLike()
        {
            return listLike;
        }
        /**
         * Metodo que permite cambiar la lista de likes de la clase
         * @param listLike La lista de likes a cambiar
         */
        public void SetListLike(List<Like> listLike)
        {
            this.listLike = listLike;
        }
        /**
         * Metodo que permite añadir un like a la lista de likes de la clase
         * @param like El like a añadir a la lista de likes
         */
        public void AddListLike(Like like)
        {
            this.like += 1;
            listLike.Add(like);
        }

        public int CreatIdLike()
        {
            int idLike = GetListLike().Count + 1;
            return idLike;
        }
    }
}
