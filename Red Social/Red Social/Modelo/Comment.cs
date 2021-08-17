using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class Comment : Information
    {
        /**
         * Constructor
         * @param id El id del comentario
         * @param author El autor del comentario
         * @param date La fecha de creacion del comentario
         * @param content El contenido del comentario
         */
        public Comment(string Id, User Author, DateTime Date, string Content) : base(Id, Author, Date, Content)
        {
        }
        public Comment()
        {

        }

        /**
         * Metodo que permite pasar a string el contenido de la clase
         * @param bloques Es la cantidad de espacios que debe haber para mostrar con identacion
         * @return Un string que muestra la clase
         */
        public string ToStrings(string bloques)
        {
            string strings = "";

            strings += bloques + "Autor: " + Author.Name +
                    "\n" + bloques + "Contenido: " + Content +
                    "\n" + bloques + "Like: " + Convert.ToString(Like) +
                    "\n" + bloques + "Comentarios: \n";

            if (ListComment == null)
            {
                strings += bloques + "     <No hay comentarios>\n";
            }
            else
            {
                foreach (Comment comment in ListComment)
                {
                    strings += "..................................................\n" +
                            comment.ToStrings(bloques + "     ") +
                            "..................................................\n";
                }
            }

            return strings;
        }

        public void MostrarComentarios()
        {
            if (ListComment != null)
            {
                foreach (Comment mostrarComment in ListComment)
                {
                    Console.WriteLine(mostrarComment.Id + ") Contenido: " + mostrarComment.Content + "\n----------------------------------\n");
                    mostrarComment.MostrarComentarios();
                }
            }
        }
    }
}
