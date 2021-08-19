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
    /// Lógica de interacción para Posting.xaml
    /// </summary>
    public partial class Posting : Window
    {
        public Posting()
        {
            InitializeComponent();

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

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
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            string content = Contenido.Text;
            if (!content.Equals(""))
            {
                if (ListUser_Elegidos.Items.Count > 1)
                {
                    List<string> listString = new List<string>();
                    List<User> listUser_Elegidos = new List<User>();

                    foreach (User user in ListUser_Elegidos.Items)
                    {
                        listUser_Elegidos.Add(user);
                    }

                    for (int i = 1; i < listUser_Elegidos.Count; i++)
                    {
                        User user = listUser_Elegidos[i];
                        listString.Add(user.Name);
                    }

                    MainWindow.SN.Post("Text", content);
                }
                else
                {
                    MainWindow.SN.Post("text", content);
                }


                Hide();
                Interaccion I = new Interaccion();
                I.Show();
            }
            else
            {
                _ = MessageBox.Show("Debe añadir un contenido a la publicacion", "Error");
            }
            
        }

        private void Elegir_Click(object sender, RoutedEventArgs e)
        {
            List<User> listUser = new List<User>();
            List<User> newListUser = new List<User>();

            foreach(User content in ListUser_Elegidos.Items)
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
            Interaccion I = new Interaccion();
            I.Show();
        }
    }
}
