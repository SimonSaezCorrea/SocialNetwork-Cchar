using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    class User
    {
        public int id; // Es el identificador de cada usuario
        private string name; // Es el nombre del usuario
        private string password; // Es la contraseña del usuario
        private bool activity; // Es si el usuario se encuentra activo o no
        private List<Post> listPost; // Es donde se almacenan las publicaciones creadas hacia él
        private List<PostShare> listPostShare; // Es donde se almacenan las publicaciones compartidas a él
        private DateTime date; // Es la fecha de creacion del usuario
        private Follows followed; // Corresponde a las personas que sigue
        private Follows followers; // Corresponde a las personas que lo siguen

        /**
         * Construcor.
         * @param id El id del usuario.
         * @param name El nombre del usuario.
         * @param password La contraseña del usuario.
         * @param date La fecha de creacion del usuario.
         */
        public User(int id, string name, string password, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            activity = false;
            listPost = new List<Post>();
            listPostShare = new List<PostShare>();
            this.date = date;
            followed = new Follows();
            followers = new Follows();
        }

        //--------------------------------------------- GET and SET --------------------------------------------------

        /**
         * Metodo que recoge el id del usuario.
         * @return El id del usuario.
         */
        public int GetId()
        {
            return id;
        }
        /**
         * Metodo que cambia el id del usuario.
         * @param id Es el id a cambiar para usuario.
         */
        public void SetId(int id)
        {
            this.id = id;
        }

        /**
         * Metodo que recoge el nombre del usuario.
         * @return El nombre del usuario.
         */
        public string GetName()
        {
            return name;
        }
        /**
         * Metodo que cambia el nombre del usuario.
         * @param name El nombre a cambiar para el usuario.
         */
        public void SetName(string name)
        {
            this.name = name;
        }

        /**
         * Metodo que recoge la contraseña del usuario.
         * @return La contraseña del usuario.
         */
        public string GetPassword()
        {
            return password;
        }
        /**
         * Metodo que cambia la contraseña del usuario.
         * @param password Es la contraseña a cambiar para usuario.
         */
        public void SetPassword(string password)
        {
            this.password = password;
        }

        /**
         * Metodo que recoge la actividad del usuario.
         * @return La actividad del usuario.
         */
        public bool GetActivity()
        {
            return activity;
        }
        /**
         * Metodo que cambia la actividad del usuario.
         * @param activity Es la actividad a cambiar para usuario.
         */
        public void SetActivity(bool activity)
        {
            this.activity = activity;
        }

        /**
         * Metodo que recoge el arreglo de publicaciones del usuario.
         * @return El arreglo de publicaciones del usuario.
         */
        public List<Post> GetListPost()
        {
            return listPost;
        }
        /**
         * Metodo que cambia el arreglo de publicaciones del usuario.
         * @param listPost Es el arreglo de publicaciones a cambiar para usuario.
         */
        public void SetListPost(List<Post> listPost)
        {
            this.listPost = listPost;
        }
        /**
         * Metodo que añade una publicacion al arreglo del usuario.
         * @param post La publicacion a añadir.
         */
        public void AddListPost(Post post)
        {
            listPost.Add(post);
        }

        /**
         * Metodo que recoge el arreglo de publicaciones compartidas del usuario.
         * @return El arreglo de publicaciones compartidas del usuario.
         */
        public List<PostShare> GetListPostShare()
        {
            return listPostShare;
        }
        /**
         * Metodo que cambia el arreglo de publicaciones compartidas del usuario.
         * @param listPostShare Es el arreglo de publicaciones compartidas a cambiar para usuario.
         */
        public void SetListPostShare(List<PostShare> listPostShare)
        {
            this.listPostShare = listPostShare;
        }
        /**
         * Metodo que añade una publicacion compartida al arreglo del usuario.
         * @param post La publicacion compartida a añadir.
         */
        public void AddListPostShare(Post post, DateTime date)
        {
            PostShare postShare = new PostShare(post, date);
            listPostShare.Add(postShare);
        }

        /**
         * Metodo que recoge la fecha de creacion del usuario.
         * @return La fecha de creacion del usuario.
         */
        public DateTime GetDate()
        {
            return date;
        }
        /**
         * Metodo que cambia la fecha de creacion del usuario.
         * @param date Es la fecha de creacion a cambiar para usuario.
         */
        public void SetDate(DateTime date)
        {
            this.date = date;
        }

        /**
         * Metodo que recoge los seguidos del usuario.
         * @return Los seguidos del usuario.
         */
        public Follows GetFollowed()
        {
            return followed;
        }
        /**
         * Metodo que cambia los seguidos del usuario.
         * @param followed Son los seguidos a cambiar para usuario.
         */
        public void SetFollowed(Follows followed)
        {
            this.followed = followed;
        }

        /**
         * Metodo que recoge los seguidores del usuario.
         * @return Los seguidores del usuario.
         */
        public Follows GetFollowers()
        {
            return followers;
        }
        /**
         * Metodo que cambia los seguidores del usuario.
         * @param followers Son los seguidores a cambiar para usuario.
         */
        public void SetFollowers(Follows followers)
        {
            this.followers = followers;
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
                    "   ID: " + Convert.ToString(GetId()) +
                    "\n   Nombre: " + GetName() +
                    "\n   Follows: " + Convert.ToString(GetFollowed().GetAmountFollows()) + " | " + Convert.ToString(GetFollowers().GetAmountFollows()) +
                    "\n   Lista de publicaciones en el perfil: \n";
            if (GetListPost() == null)
            {
                strings += "      <No hay publicaciones>\n";
            }
            else
            {
                foreach (Post post in GetListPost())
                {
                    strings = strings +
                            post.ToString() +
                            "-------------------------------------\n";
                }
            }
            strings += "   Lista de publicaciones compartidas en el perfil: \n";
            if (GetListPostShare() == null)
            {
                strings += "      <No hay publicaciones compartidas>\n";
            }
            else
            {
                foreach (PostShare postShare in GetListPostShare())
                {
                    strings += postShare.GetPost().ToStrings() + "-------------------------------------\n";
                }
            }

            return strings;
        }

    }
}
