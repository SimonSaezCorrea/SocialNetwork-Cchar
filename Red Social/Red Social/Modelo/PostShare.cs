using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class PostShare
    {
        private Post post; // El post compartido
        private DateTime date; // La fecha que se compartido

        /**
         * Constructor
         * @param post EL post que se compartio
         * @param date La fecha en la que se compartido
         */
        public PostShare(Post post, DateTime date)
        {
            this.post = post;
            this.date = date;
        }

        /**
         * Metodo que permite recoger el post compartido
         * @return El post compartido
         */
        public Post GetPost()
        {
            return post;
        }
        /**
         * Metodo que permite cambiar el post compartido
         * @param post El post compartido a cambiar
         */
        public void SetPost(Post post)
        {
            this.post = post;
        }

        /**
         * Metodo que permite recoger la fecha compartida
         * @return La fecha compartida
         */
        public DateTime GetDate()
        {
            return date;
        }
        /**
         * Metodo que permite cambiar la fecha compartida
         * @param date La fecha compartida a cambiar
         */
        public void SetDate(DateTime date)
        {
            this.date = date;
        }
    }
}
