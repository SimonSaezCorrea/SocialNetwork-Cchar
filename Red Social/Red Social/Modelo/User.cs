using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class User
    {
        public string Id { get; set; } // Es el identificador de cada usuario, ademas se añaden su get y set
        public string Name { get; set; } // Es el nombre del usuario, ademas se añaden su get y set
        public string Password { get; set; } // Es la contraseña del usuario, ademas se añaden su get y set
        public bool Activity { get; set; } // Es si el usuario se encuentra activo o no, ademas se añaden su get y set
        public List<Post> ListPost { get; set; } // Es donde se almacenan las publicaciones creadas hacia él, ademas se añaden su get y set
        public List<PostShare> ListPostShare { get; set; } // Es donde se almacenan las publicaciones compartidas a él, ademas se añaden su get y set
        public DateTime Date { get; set; } // Es la fecha de creacion del usuario, ademas se añaden su get y set
        public Follows Followed { get; set; } // Corresponde a las personas que sigue, ademas se añaden su get y set
        public Follows Followers { get; set; } // Corresponde a las personas que lo siguen, ademas se añaden su get y set

        /**
         * Construcor.
         * @param id El id del usuario.
         * @param name El nombre del usuario.
         * @param password La contraseña del usuario.
         * @param date La fecha de creacion del usuario.
         */
        public User(string Id, string Name, string Password, DateTime Date)
        {
            this.Id = Id;
            this.Name = Name;
            this.Password = Password;
            Activity = false;
            ListPost = new List<Post>();
            ListPostShare = new List<PostShare>();
            this.Date = Date;
            Followed = new Follows();
            Followers = new Follows();
        }
        public User()
        {

        }

        //--------------------------------------------- Add --------------------------------------------------

        /**
         * Metodo que añade una publicacion al arreglo del usuario.
         * @param post La publicacion a añadir.
         */
        public void AddListPost(Post post)
        {
            ListPost.Add(post);
        }

        /**
         * Metodo que añade una publicacion compartida al arreglo del usuario.
         * @param post La publicacion compartida a añadir.
         */
        public void AddListPostShare(Post post, DateTime date)
        {
            PostShare postShare = new PostShare(post, date);
            ListPostShare.Add(postShare);
        }

        //---------------------------------------------- TO STRING ---------------------------------------------------

        /**
         * Metodo que transforma el contenido de la clase en un string a mostrar para mejor visibidad y ver los cambios.
         * @return Un string que contiene todo los datos a mostrar.
         */
        public string ToStrings()
        {
            string strings = "";
            strings = strings +
                    "   ID: " + Id +
                    "\n   Nombre: " + Name +
                    "\n   Follows: " + Convert.ToString(Followed.AmountFollows) + " | " + Convert.ToString(Followers.AmountFollows) +
                    "\n   Lista de publicaciones en el perfil: \n";
            if (ListPost == null)
            {
                strings += "      <No hay publicaciones>\n";
            }
            else
            {
                foreach (Post post in ListPost)
                {
                    strings = strings +
                            post.ToString() +
                            "-------------------------------------\n";
                }
            }
            strings += "   Lista de publicaciones compartidas en el perfil: \n";
            if (ListPostShare == null)
            {
                strings += "      <No hay publicaciones compartidas>\n";
            }
            else
            {
                foreach (PostShare postShare in ListPostShare)
                {
                    strings += postShare.Post.ToStrings() + "-------------------------------------\n";
                }
            }

            return strings;
        }

    }
}
