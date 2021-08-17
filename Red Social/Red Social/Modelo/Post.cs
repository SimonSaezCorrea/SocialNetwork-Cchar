using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class Post : Information
    {
        public string TypePost { get; set; } // Determina el tipo de publicacion
        public int AmountShare { get; set; } // Cantidad de veces compartida

        /**
         * Constructor
         * @param id El id del usuario
         * @param author El creador de la publicacion
         * @param date La fecha de creacion
         * @param content El contenido
         * @param typePost El tipo de post
         */
        public Post(string Id, User Author, DateTime Date, string Content, string TypePost) : base(Id, Author, Date, Content)
        {
            this.TypePost = TypePost;
            AmountShare = 0;
        }

        public Post() : base()
        {
            
        }

        /**
         * Metodo que permite pasar a string el contenido de la clase post
         * @return Un string donde esta todo el contenido de la clase post
         */
        public string ToStrings()
        {
            string strings = "";
            strings += "      Autor: " + Author.Name +
                    "\n      Contenido: " + Content +
                    "\n      Like: " + Convert.ToString(Like) +
                    "\n      Cantidad de veces compartida: " + Convert.ToString(AmountShare) +
                    "\n      Comentarios: \n";
            if (ListComment == null)
            {
                strings += "         <No hay comentarios>\n";
            }
            else
            {
                foreach (Comment comment in ListComment)
                {
                    strings += "..................................................\n" +
                            comment.ToStrings("          ") +
                            "..................................................\n";
                }
            }
            return strings;
        }
    }
}
