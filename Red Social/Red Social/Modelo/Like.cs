using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class Like
    {
        private int id; // El id del like
        private DateTime date; // La fecha de creacion del dato
        private User author; // El autor 

        /**
         * Constructor
         * @param id El id del like
         * @param date La fecha de creacion del like
         * @param author El autor del like
         */
        public Like(int id, DateTime date, User author)
        {
            this.id = id;
            this.date = date;
            this.author = author;
        }

        /**
         * Metodo que permite recoger el id del like
         * @return El id del like
         */
        public int GetId()
        {
            return id;
        }
        /**
         * Metodo que permite cambiar el id del like
         * @param id El id a cambiar del like
         */
        public void SetId(int id)
        {
            this.id = id;
        }

        /**
         * Metodo que permite recoger la fecha de creacion del like
         * @return La fecha de creacion del like
         */
        public DateTime GetDate()
        {
            return date;
        }
        /**
         * Metodo que permite cambiar la fecha de creacion del like
         * @param date La fecha de creacion a cambiar del like
         */
        public void SetDate(DateTime date)
        {
            this.date = date;
        }

        /**
         * Metodo que permite recoger el autor del like
         * @return EL autor del like
         */
        public User GetAuthor()
        {
            return author;
        }
        /**
         * Metodo que permite cambiar el autor del like
         * @param author El autor a cambiar del like
         */
        public void SetAuthor(User author)
        {
            this.author = author;
        }
    }
}
