using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class Socialnetwork : IAccionable
    {
        public string Name { get; set; } // Nombre de la socialnetwork
        public DateTime Date { get; set; } // Fecha de creacion
        public List<User> ListUser { get; set; } // Lista de usuarios que contiene la socialnetwork
        public List<Post> ListPost { get; set; } // Lista de publicaciones que contiene la socialnetwork
        public List<Comment> ListComment { get; set; } // Lista de comentarios que contiene la socialnetwork

        /**
         * Constructor.
         * @param name Nombre de la socialnetwork.
         * @param date Fecha de creacion de la socialnetwork.
         */
        public Socialnetwork(string Name, DateTime Date)
        {
            this.Name = Name;
            this.Date = Date;
            ListUser = new List<User>();
            ListPost = new List<Post>();
            ListComment = new List<Comment>();
        }

        //------------------------------------- ACCIONABLE -------------------------------------------------------

        /**
         * Metodo que permite hacer login (conectar) de un usuario de la socialnetwork y retornar una verificacion booleana para saber si se activo o no.
         * @param name Nombre del usuario a conectar en la socialnetwork.
         * @param password Contraseña del usuario a conectar en la socialnetwork.
         * @return Verificacion de conectividad.
         */
        public bool Login(string name, string password)
        {
            if (ExistUser(name, password))
            {
                User user = SearchUser(name);
                user.Activity = true;
                return true;
            }
            return false;
        }
        /**
         * Metodo que permite registrar y conectar a un nuevo usuario a la socialnetwork y retornar una verificacion booleana para saber si se creo y que en consecuencia tambien se conecta.
         * @param name Nombre del usuario a crear.
         * @param password Contraseña del usuario a crear.
         * @return Verificacion de creacion y a su vez de conectividad.
         */

        public bool Register(string name, string password)
        {
            if (!ExistUser(name, password))
            {
                User user = new User(CreateIDUser(), name, password, DateTime.Now);
                user.Activity = true;
                AddListUser(user);
                return true;
            }
            return false;
        }

        /**
         * Permite desconectar a una cuenta conectada en la socialnetwork.
         */

        public void Logout()
        {
            SearchUserActive().Activity = false;
        }

        /**
         * Metodo que permite crear un post hacia si mismo.
         * @param typePost Tipo de publicacion a hacer (Puede ser "Text", "Photo", "Video", "Audio").
         * @param content Contenido de la publicion que se va a hacer.
         */
        public void Post(string typePost, string content)
        {
            User author = SearchUserActive();

            if (author != null)
            {
                Post post = new Post(CreateIDPost(), author, DateTime.Now, content, typePost);
                AddListPost(post);
                author.AddListPost(post);
            }
        }
        /**
         * Metodo que permite crear una publicacion hacia otros usuarios (Mas de uno).
         * Los usuarios deben seguirse mutuamente para efectuar la publicacion entre ambos, es decir que el usuario que envia debe seguir al es enviado y viceversa tambien.
         * En otras formas si un user1 envia a un user2, el user 1 debe seguir al user 2 y el user 2 debe seguir al user1.
         * @param typePost Tipo de publicacion a hacer (Puede ser "Text", "Photo", "Video", "Audio").
         * @param content Contenido de la publicion que se va a hacer.
         * @param listStringUser Arreglo de nombres de usuarios a enviar la publicacion.
         */
        public void Post(string typePost, string content, List<User> listStringUser)
        {
            User author = SearchUserActive();
            bool seEnvioUno = false;
            if (author != null)
            {
                Post post = new Post(CreateIDPost(), author, DateTime.Now, content, typePost);
                int i;
                for(i = 1; i < listStringUser.Count; i++)
                {
                    User user = listStringUser[i];
                    if (user.Followers.ExistFollow(author) && user.Followed.ExistFollow(author))
                    {
                        user.AddListPost(post);
                        seEnvioUno = true;
                    }
                }
                if (seEnvioUno)
                {
                    AddListPost(post);
                }
            }
        }

        /**
         * Metodo que permite hacer follow a un usuarios distinto al que lo hace.
         * Es decir que un user1 no puede seguir a user1, porque no se puede seguir a si mismo.
         * @param name El nombre del usuario a seguir.
         */
        public void Follow(User user)
        {
            User userConnect = SearchUserActive();
            if (!user.Equals(userConnect))
            {
                userConnect.Followed.AddListFollows(user);
                user.Followers.AddListFollows(userConnect);
            }

        }

        /**
         * Metodo que permite compartir un post a usuarios (Y a si mismo tambien).
         * Los usuarios deben seguirse mutuamente para efectuar la publicacion entre ambos, es decir que el usuario que envia debe seguir al es enviado y viceversa tambien.
         * En otras formas si un user1 envia a un user2, el user 1 debe seguir al user 2 y el user 2 debe seguir al user1.
         * 
         * Cabe desctacar que si user1 envia una publicacion a user1, no es necesario seguirse porque es imposible que se pueda seguir.
         * @param idPost Es el id de la publicacion.
         * @param listUser Un arreglo de usuarios a la que va dirijida.
         */
        public void Share(Post Posting, List<User> listUser)
        {
            foreach (User Usuario in listUser)
            {
                Console.WriteLine("Usuario = " + Usuario.Name);
                if (Usuario.Name.Equals(SearchUserActive().Name))
                {
                    Usuario.AddListPostShare(Posting, DateTime.Now);
                    Posting.AmountShare += 1;
                }
                else if (Usuario.Followers.ExistFollow(SearchUserActive()) && Usuario.Followed.ExistFollow(SearchUserActive()))
                {
                    Usuario.AddListPostShare(Posting, DateTime.Now);
                    Posting.AmountShare += 1;
                }
            }
        }

        /**
         * Metodo que permite visualizar una socialnetwork o el usuario activo.
         */
        public void Visualize()
        {
            PrintSocialNetwork(SocialNetworkToString());
        }
        /**
         * Metodo que permite extraer un string del socialnetwork.
         * @return Un string donde contiene todo los datos necesarios para mostrar.
         */
        private string SocialNetworkToString()
        {
            string strings = "";

            User userActivo = SearchUserActive();

            if (userActivo != null)
            {
                strings += userActivo.ToStrings();
                return strings;
            }

            strings += "Nombre: " + Name +
                    "\nUsuarios inscritos: \n";
            foreach (User users in ListUser)
            {
                strings += users.ToStrings() +
                        "^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n";
            }

            return strings;
        }
        /**
         * Metodo que permite mostrar la socialnetwork o usuario activo.
         * @param string Un texto que se va a mostrar.
         */
        private void PrintSocialNetwork(string strings)
        {
            Console.WriteLine(strings);
        }

        /**
         * Metodo que permite hacer un comentario a un post.
         * @param post Es a la publicacion que va dirijida.
         * @param text Es el comentario que se desea colocar.
         */
        public void Comment(Post post, string text)
        {
            User author = SearchUserActive();
            if (author != null)
            {
                Comment comment = new Comment(CreateIDComment(), SearchUserActive(), DateTime.Now, text);
                User user = post.Author;
                if ((author.Followers.ExistFollow(user) && author.Followed.ExistFollow(user)) || author.Equals(user))
                {
                    AddListComment(comment);
                    post.AddListComment(comment);
                }
            }
        }
        /**
         * Metodo que permite hacer un comentario a un comentario.
         * @param comment Es al comentario que va dirijida.
         * @param text Es el comentario que se desea colocar.
         */
        public void Comment(Comment comment, string text)
        {
            User author = SearchUserActive();
            if (author != null)
            {
                Comment commentComment = new Comment(CreateIDComment(), SearchUserActive(), DateTime.Now, text);
                User user = comment.Author;
                if ((user.Followers.ExistFollow(author) && user.Followed.ExistFollow(author)) || author.Equals(user))
                {
                    AddListComment(commentComment);
                    comment.AddListComment(commentComment);
                }
            }
        }

        /**
         * Metodo que permite dar like a un comentario
         * @param comment El comentario a dar like
         */
        public bool Like(Comment comment)
        {
            User author = SearchUserActive();
            if (author != null)
            {
                Like like = new Like(comment.CreatIdLike(), DateTime.Now, SearchUserActive());
                User user = comment.Author;
                if (!comment.ExistUserLike(user))
                {
                    comment.AddListLike(like);
                    return true;
                }
            }

            return false;


        }
        /**
         * Metodo que permite dar like a una publicacion
         * @param post La publicacion a dar like
         */
        public bool Like(Post post)
        {
            User author = SearchUserActive();
            if (author != null)
            {
                Like like = new Like(post.CreatIdLike(), DateTime.Now, SearchUserActive());
                User user = post.Author;
                if ((user.Followers.ExistFollow(author) && user.Followed.ExistFollow(author)) || user.Equals(author))
                {
                    if (!post.ExistUserLike(user))
                    {
                        post.AddListLike(like);
                        return true;
                    }
                }
            }

            return false;

        }

        //--------------------------------------------------- CREACION ID -------------------------------------------------------

        /**
         * Metodo que permite crear el siguiente id del arreglo de usuarios.
         * @return el id siguiente que corresponde.
         */
        private string CreateIDUser()
        {
            return Convert.ToString(1 + ListUser.Count);
        }

        /**
         * Metodo que permite crear el siguiente id del arreglo de publicaciones.
         * @return el id siguiente que corresponde.
         */
        private string CreateIDPost()
        {
            return Convert.ToString(1 + ListPost.Count);
        }

        /**
         * Metodo que permite crear el siguiente id del arreglo de comentarios.
         * @return el id siguiente que corresponde.
         */
        private string CreateIDComment()
        {
            return Convert.ToString(1 + ListComment.Count);
        }

        //------------------------------------------------- EXISTENCIA --------------------------------------------------------

        /**
         * Metodo que permite saber si existe tal usuario mediante el nombre.
         * @param name Es el nombre del usuario que se desea saber su existencia.
         * @return Una sentencia para saber si existe.
         */
        public bool ExistUser(string name)
        {
            foreach (User user in ListUser)
            {
                if (name.Equals(user.Name))
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Metodo que permite saber si existe tal usuario mediante su nombre y la contraseña.
         * @param name Es el nombre del usuario que se desea saber su existencia.
         * @param password Es la contraseña del usuario que se desea saber su existencia.
         * @return Una sentencia para saber si existe.
         */
        public bool ExistUser(string name, string password)
        {
            foreach (User user in ListUser)
            {
                if (name.Equals(user.Name) && password.Equals(user.Password))
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Metodo que permite saber si existe tal usuario mediante su id.
         * @param id Es el id del usuario que se desea saber su existencia.
         * @return Una sentencia para saber si existe.
         */
        public bool ExistUser(int id)
        {
            foreach (User user in ListUser)
            {
                if (Convert.ToString(id).Equals(user.Id))
                {
                    return true;
                }
            }
            return false;
        }


        //-------------------------------------------------- SEARCH ----------------------------------------------------------

        /**
         * Metodo que permite buscar dentro de la lista de usuarios a un usuario que este activo.
         * @return El usuario encontrado en la lista de usuarios.
         */
        public User SearchUserActive()
        {

            foreach (User user in ListUser)
            {
                if (user.Activity)
                {
                    return user;
                }
            }
            return null;
        }

        /**
         * Metodo que permite buscar dentro de una lista de usuarios a un usuario mediante su nombre.
         * @param name Es el nombre del usuario que se desea buscar.
         * @return El usuario encontrado en la lista de usuarios.
         */
        public User SearchUser(string name)
        {
            foreach (User user in ListUser)
            {
                if (name.Equals(user.Name))
                {
                    return user;
                }
            }
            return null;
        }

        /**
         * Metodo que permite buscar dentro de una lista de usuarios un usuario mediante su id.
         * @param id Es el id del usuario que se desea buscar.
         * @return El usuario encontrado en la lista de usuarios.
         */
        public User SearchUser(int id)
        {
            foreach (User user in ListUser)
            {
                if (Convert.ToString(id).Equals(user.Id))
                {
                    return user;
                }
            }
            return null;
        }

        /**
         * Metodo que permite buscar dentro de una lista de una publicacion una publicacion mediante su id.
         * @param id Es el id de la publicacion que se desea buscar.
         * @return El post encontrado en la lista de publicaciones.
         */
        public Post SearchPost(int id)
        {
            foreach (Post post in ListPost)
            {
                if (Convert.ToString(id).Equals(post.Id))
                {
                    return post;
                }
            }
            return null;
        }

        /**
         * Metodo que permite buscar dentro de una lista de comentarios un comentario mediante su id.
         * @param id Es el id del comentario que se desea buscar.
         * @return El comentario encontrado en la lista de comentarios.
         */
        public Comment SearchComment(int id)
        {
            foreach (Comment comment in ListComment)
            {
                if (Convert.ToString(id).Equals(comment.Id))
                {
                    return comment;
                }
            }
            return null;
        }


        //--------------------------------------------- GET and SET --------------------------------------------------

        /**
         * Metodo que permite añadir un elemento al arreglo de usuarios.
         * @param user Es el usuario que se desea agregar.
         */
        public void AddListUser(User user)
        {
           ListUser.Add(user);
        }

        /**
         * Metodo que permite añadir un elemento al arreglo de publicaciones.
         * @param post Es la publicacion que se desea agregar.
         */
        public void AddListPost(Post post)
        {
            ListPost.Add(post);
        }

        /**
         * Metodo que permite añadir un elemento al arreglo de comentarios.
         * @param comment Es el comentario que se desea agregar.
         */
        public void AddListComment(Comment comment)
        {
            ListComment.Add(comment);
        }
    }
}
