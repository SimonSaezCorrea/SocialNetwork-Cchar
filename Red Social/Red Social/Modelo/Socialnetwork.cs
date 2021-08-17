﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class Socialnetwork : Accionable
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
                Console.WriteLine("El usuario " + user.Name + " se conecto a la red social");
                return true;
            }
            Console.WriteLine("El usuario no existe");
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
                Console.WriteLine("El usuario " + user.Name + " se creo y conecto a la red social");
                return true;
            }
            Console.WriteLine("El usuario ya existe");
            return false;
        }

        /**
         * Permite desconectar a una cuenta conectada en la socialnetwork.
         */

        public void Logout()
        {
            Console.WriteLine("El usuario " + SearchUserActive().Name + " se desconecto de la red social\n\n");

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
                Console.WriteLine("Publicaciones creada correctamente");
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
        public void Post(string typePost, string content, List<string> listStringUser)
        {
            User author = SearchUserActive();
            bool seEnvioUno = false;
            if (author != null)
            {
                Post post = new Post(CreateIDPost(), author, DateTime.Now, content, typePost);
                foreach (string nameUser in listStringUser)
                {
                    if (ExistUser(nameUser))
                    {
                        User user = SearchUser(nameUser);
                        if (user.Followers.ExistFollow(author) && user.Followed.ExistFollow(author))
                        {
                            user.AddListPost(post);
                            seEnvioUno = true;
                            Console.WriteLine("Publicacion enviada correctamente a " + user.Name);
                        }
                        else
                        {
                            Console.WriteLine("No se puede enviar el post a " + user.Name + ", no se siguen mutuamente");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No existe el Usuario" + nameUser + "para enviarle el post");
                    }
                }
                if (seEnvioUno)
                {
                    AddListPost(post);
                    Console.WriteLine("Publicaciones enviadas correctamente");
                }
            }
        }

        /**
         * Metodo que permite hacer follow a un usuarios distinto al que lo hace.
         * Es decir que un user1 no puede seguir a user1, porque no se puede seguir a si mismo.
         * @param name El nombre del usuario a seguir.
         */
        public void Follow(string name)
        {

            User userConnect = SearchUserActive();
            if (!name.Equals(userConnect.Name))
            {
                if (ExistUser(name))
                {
                    User user = SearchUser(name);

                    userConnect.Followed.AddListFollows(user);
                    user.Followers.AddListFollows(userConnect);

                    Console.WriteLine("El usuario " + userConnect.Name + " sigue a " + user.Name);
                }
                else
                {
                    Console.WriteLine("El usuario no existe");
                }
            }
            else
            {
                Console.WriteLine("No puedes seguir a ti mismo");
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
        public void Share(int idPost, List<string> listUser)
        {
            Post post = SearchPost(idPost);
            foreach (string nameUser in listUser)
            {
                if (ExistUser(nameUser))
                {
                    User user = SearchUser(nameUser);
                    if (user.Name.Equals(SearchUserActive().Name))
                    {
                        user.AddListPostShare(post, DateTime.Now);
                        Console.WriteLine("La publicacion se compartio correctamente a su cuenta");
                    }
                    else if (user.Followers.ExistFollow(SearchUserActive()) && user.Followed.ExistFollow(SearchUserActive()))
                    {
                        user.AddListPostShare(post, DateTime.Now);
                        Console.WriteLine("La publicacion se compartio correctamente a la cuenta de " + user.Name);
                    }
                    else
                    {
                        Console.WriteLine("No se puede compartir, no se siguen mutuamente");
                    }
                }
                else
                {
                    Console.WriteLine("No existe el usuario " + nameUser + "\n");
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
                    Console.WriteLine("Cometario enviado correctamente a la publicacion " + post.Id);
                }
                else
                {
                    Console.WriteLine("No se puede enviar el comentario a la publicacion " + post.Id + ", no se siguen mutuamente (el autor con el que envia el comentario)");
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
                    Console.WriteLine("Cometario enviado correctamente al comentario " + comment.Id);
                }
                else
                {
                    Console.WriteLine("No se puede enviar el comentario al comentario " + comment.Id + ", no se siguen mutuamente (el autor con el que envia el comentario)");
                }
            }
            else
            {
                Console.WriteLine("No hay un usuario conectado");
            }
        }

        /**
         * Metodo que permite dar like a un comentario
         * @param comment El comentario a dar like
         */
        public void Like(Comment comment)
        {
            User author = SearchUserActive();
            if (author != null)
            {
                Like like = new Like(comment.CreatIdLike(), DateTime.Now, SearchUserActive());
                User user = comment.Author;
                if (user.Followers.ExistFollow(author) && user.Followed.ExistFollow(author))
                {
                    comment.AddListLike(like);
                    Console.WriteLine("Like enviado correctamente al comentario " + comment.Id);
                }
                else
                {
                    Console.WriteLine("No se puede enviar el Like al comentario " + comment.Id + ", no se siguen mutuamente (el autor con el que envia el comentario)");
                }
            }
            else
            {
                Console.WriteLine("No hay un usuario conectado");
            }


        }
        /**
         * Metodo que permite dar like a una publicacion
         * @param post La publicacion a dar like
         */
        public void Like(Post post)
        {
            User author = SearchUserActive();
            if (author != null)
            {
                Like like = new Like(post.CreatIdLike(), DateTime.Now, SearchUserActive());
                User user = post.Author;
                if (user.Followers.ExistFollow(author) && user.Followed.ExistFollow(author))
                {
                    post.AddListLike(like);
                    Console.WriteLine("Like enviado correctamente a la publicacion " + post.Id);
                }
                else
                {
                    Console.WriteLine("No se puede enviar el Like a la publicacion " + post.Id + ", no se siguen mutuamente (el autor con el que envia el comentario)");
                }
            }
            else
            {
                Console.WriteLine("No hay un usuario conectado");
            }



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
