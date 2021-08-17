using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class PostShare
    {
        public Post Post { get; set; } // El post compartido
        public DateTime Date { get; set; } // La fecha que se compartido

        /**
         * Constructor
         * @param post EL post que se compartio
         * @param date La fecha en la que se compartido
         */
        public PostShare(Post Post, DateTime Date)
        {
            this.Post = Post;
            this.Date = Date;
        }
    }
}
