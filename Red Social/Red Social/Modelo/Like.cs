using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class Like
    {
        public string Id { get; set; } // El id del like
        public DateTime Date { get; set; } // La fecha de creacion del dato
        public User Author { get; set; } // El autor 

        /**
         * Constructor
         * @param id El id del like
         * @param date La fecha de creacion del like
         * @param author El autor del like
         */
        public Like(string Id, DateTime Date, User Author)
        {
            this.Id = Id;
            this.Date = Date;
            this.Author = Author;
        }
    }
}
