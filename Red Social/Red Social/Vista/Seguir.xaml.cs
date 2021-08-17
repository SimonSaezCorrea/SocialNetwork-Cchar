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
    /// Lógica de interacción para Seguir.xaml
    /// </summary>
    public partial class Seguir : Window
    {
        public Seguir()
        {
            InitializeComponent();

            List<User> listPublicaciones = new List<User>();

            listPublicaciones.Add(new User() { Name = "Nombre" });

            foreach (User user in MainWindow.SN.ListUser)
            {
                if (!MainWindow.SN.SearchUserActive().Followed.ExistFollow(user) && !MainWindow.SN.SearchUserActive().Equals(user))
                {
                    listPublicaciones.Add(user);
                }
            }
            ListUser.ItemsSource = listPublicaciones;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Interaccion I = new Interaccion();
            I.Show();
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (ListUser.SelectedItem != null)
            {
                int index = ListUser.SelectedIndex;
                if (index != 0)
                {
                    User user = (User)ListUser.SelectedItem;
                    MainWindow.SN.Follow(user.Name);
                    Hide();
                    Interaccion I = new Interaccion();
                    I.Show();
                }
            }
            else
            {
                _ = MessageBox.Show("Debe elegir un usuario", "Error");
            }
        }
    }
}
