using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class Post : Information
    {
        private string typePost; // Determina el tipo de publicacion
        private int amountShare; // Cantidad de veces compartida

        /**
         * Constructor
         * @param id El id del usuario
         * @param author El creador de la publicacion
         * @param date La fecha de creacion
         * @param content El contenido
         * @param typePost El tipo de post
         */
        public Post(int id, User author, DateTime date, string content, string typePost) : base(id, author, date, content)
        {
            this.typePost = typePost;
            amountShare = 0;
        }

        /**
         * Metodo que permite recoger el tipo de la publicacion
         * @return El tipo de la publicacion
         */
        public string GetTypePost()
        {
            return typePost;
        }
        /**
         * Metodo que permite cambiar el tipo de publicacion
         * @param typePost El tipo de publicacion a cambiar
         */
        public void SetTypePost(string typePost)
        {
            this.typePost = typePost;
        }

        /**
         * Metodo que permite recoger la cantidad de compartidas
         * @return La cantidad de veces compartida
         */
        public int GetAmountShare()
        {
            return amountShare;
        }
        /**
         * Metodo que permite cambiar la cantidad de compartidas
         * @param amountShare La cantidad de compartidas
         */
        public void SetAmountShare(int amountShare)
        {
            this.amountShare = amountShare;
        }

        /**
         * Metodo que permite pasar a string el contenido de la clase post
         * @return Un string donde esta todo el contenido de la clase post
         */
        public string ToStrings()
        {
            string strings = "";
            strings += "      Autor: " + GetAuthor().GetName() +
                    "\n      Contenido: " + GetContent() +
                    "\n      Like: " + Convert.ToString(GetLike()) +
                    "\n      Cantidad de veces compartida: " + Convert.ToString(GetAmountShare()) +
                    "\n      Comentarios: \n";
            if (GetListComment() == null)
            {
                strings += "         <No hay comentarios>\n";
            }
            else
            {
                foreach (Comment comment in GetListComment())
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
