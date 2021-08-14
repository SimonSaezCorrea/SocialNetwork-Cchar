using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social
{
    public class Follows
    {
        private int amountFollows; // Cantidad de follows
        private List<User> listFollows; // Lista de usuarios que sigue o lo siguen


        /**
         * Constructor
         */
        public Follows()
        {
            amountFollows = 0;
            listFollows = new List<User>();
        }

        /**
         * Metodo que permite saber si existe un usuario que lo siga
         * @param user El usuario que se desea compronar
         * @return Una sentencia booleana que diga si existe o no existe
         */
        public bool ExistFollow(User user)
        {

            foreach (User isUser in GetListFollows())
            {
                if (isUser.Equals(user))
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Metodo que permite recoger la cantidad de follows
         * @return La cantidad de follows
         */
        public int GetAmountFollows()
        {
            return amountFollows;
        }
        /**
         * Metodo que permite cambiar la cantidad de follows
         * @param amountFollows La cantidad de follows a cambiar
         */
        public void SetAmountFollows(int amountFollows)
        {
            this.amountFollows = amountFollows;
        }

        /**
         * Metodo que permite recoger la lista de usuarios que sigue o lo siguen
         * @return La lista de usuarios
         */
        public List<User> GetListFollows()
        {
            return listFollows;
        }
        /**
         * Metodo que permite cambiar la lista de usuarios que sigue o lo siguen
         * @param listFollows La lista de usuarios a cambiar
         */
        public void SetListFollows(List<User> listFollows)
        {
            this.listFollows = listFollows;
        }
        /**
         * Metodo que permite añadir un usuario a la lista de usuarios
         * @param user El usuario a añadir
         */
        public void AddListFollows(User user)
        {
            amountFollows += 1;
            listFollows.Add(user);
        }
    }
}
