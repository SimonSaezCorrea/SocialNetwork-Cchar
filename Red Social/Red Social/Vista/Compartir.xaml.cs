using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Red_Social
{
    /// <summary>
    /// Lógica de interacción para Compartir.xaml
    /// </summary>
    public partial class Compartir : Window
    {
        public Compartir()
        {
            InitializeComponent();
            List<User> listUser = new List<User>();
            List<User> listUser_Elegidos = new List<User>();


            listUser.Add(new User() { Name = "Nombre" });
            listUser_Elegidos.Add(new User() { Name = "Nombre" });

            foreach (User user in MainWindow.SN.ListUser)
            {
                if (!user.Equals(MainWindow.SN.SearchUserActive()) && MainWindow.SN.SearchUserActive().Followers.ExistFollow(user) && MainWindow.SN.SearchUserActive().Followed.ExistFollow(user))
                {
                    listUser.Add(user);
                }
            }
            ListUser.ItemsSource = listUser;
            ListUser_Elegidos.ItemsSource = listUser_Elegidos;
        }

        private void Elegir_Click(object sender, RoutedEventArgs e)
        {
            List<User> listUser = new List<User>();
            List<User> newListUser = new List<User>();

            foreach (User content in ListUser_Elegidos.Items)
            {
                newListUser.Add(content);
            }

            foreach (User content in ListUser.Items)
            {
                if (content.Name.Equals("Nombre"))
                {
                    listUser.Add(content);
                }
                else if (content.Equals(ListUser.SelectedItem))
                {
                    newListUser.Add(content);
                }
                else
                {
                    listUser.Add(content);
                }
            }
            ListUser_Elegidos.ItemsSource = newListUser;
            ListUser.ItemsSource = listUser;
        }

        private void Retornar_Click(object sender, RoutedEventArgs e)
        {
            List<User> listUser = new List<User>();
            List<User> newListUser = new List<User>();

            foreach (User content in ListUser.Items)
            {
                newListUser.Add(content);
            }

            foreach (User content in ListUser_Elegidos.Items)
            {
                if (content.Name.Equals("Nombre"))
                {
                    listUser.Add(content);
                }
                else if (content.Equals(ListUser_Elegidos.SelectedItem))
                {
                    newListUser.Add(content);
                }
                else
                {
                    listUser.Add(content);
                }
            }
            ListUser.ItemsSource = newListUser;
            ListUser_Elegidos.ItemsSource = listUser;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AbrirPost AP = new AbrirPost();
            AP.Show();
        }

        private void Acetar_Click(object sender, RoutedEventArgs e)
        {
            if(ListUser_Elegidos.Items.Count == 1)
            {
                ListUser_Elegidos.Items.Add(MainWindow.SN.SearchUserActive());
            }

            List<User> listUser = new List<User>();
            int i;
            for(i = 1; i < ListUser_Elegidos.Items.Count; i++)
            {
                User user = (User)ListUser_Elegidos.Items[i];
                listUser.Add(user);
            }

            Post post = (Post)Interaccion.listaDePublicaciones.SelectedItem;

            MainWindow.SN.Share(post, listUser);

            Hide();
            AbrirPost AP = new AbrirPost();
            AP.Show();
        }

        private void Aceptar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                if (ListUser_Elegidos.Items.Count == 1)
                {
                    ListUser_Elegidos.Items.Add(MainWindow.SN.SearchUserActive());
                }

                List<User> listUser = new List<User>();
                int i;
                for (i = 1; i < ListUser_Elegidos.Items.Count; i++)
                {
                    User user = (User)ListUser_Elegidos.Items[i];
                    listUser.Add(user);
                }

                Post post = (Post)Interaccion.listaDePublicaciones.SelectedItem;

                MainWindow.SN.Share(post, listUser);

                Hide();
                AbrirPost AP = new AbrirPost();
                AP.Show();
            }
        }
    }
}
