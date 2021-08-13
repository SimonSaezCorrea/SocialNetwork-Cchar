using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    class Comment : Information
    {
        /**
         * Constructor
         * @param id El id del comentario
         * @param author El autor del comentario
         * @param date La fecha de creacion del comentario
         * @param content El contenido del comentario
         */
        public Comment(int id, User author, DateTime date, string content) : base(id, author, date, content)
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

            strings += bloques + "Autor: " + GetAuthor().GetName() +
                    "\n" + bloques + "Contenido: " + GetContent() +
                    "\n" + bloques + "Like: " + Convert.ToString(GetLike()) +
                    "\n" + bloques + "Comentarios: \n";

            if (GetListComment() == null)
            {
                strings += bloques + "     <No hay comentarios>\n";
            }
            else
            {
                foreach (Comment comment in GetListComment())
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
            if (GetListComment() != null)
            {
                foreach (Comment mostrarComment in GetListComment())
                {
                    Console.WriteLine(Convert.ToString(mostrarComment.GetId()) + ") Contenido: " + mostrarComment.GetContent() + "\n----------------------------------\n");
                    mostrarComment.MostrarComentarios();
                }
            }
        }
    }
}
