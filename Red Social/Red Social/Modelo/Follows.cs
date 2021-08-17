using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class Follows
    {
        public int AmountFollows { get; set; } // Cantidad de follows
        public List<User> ListFollows { get; set; } // Lista de usuarios que sigue o lo siguen


        /**
         * Constructor
         */
        public Follows()
        {
            AmountFollows = 0;
            ListFollows = new List<User>();
        }

        /**
         * Metodo que permite saber si existe un usuario que lo siga
         * @param user El usuario que se desea compronar
         * @return Una sentencia booleana que diga si existe o no existe
         */
        public bool ExistFollow(User user)
        {

            foreach (User isUser in ListFollows)
            {
                if (isUser.Equals(user))
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Metodo que permite añadir un usuario a la lista de usuarios
         * @param user El usuario a añadir
         */
        public void AddListFollows(User user)
        {
            AmountFollows += 1;
            ListFollows.Add(user);
        }
    }
}
