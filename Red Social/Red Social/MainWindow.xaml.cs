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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Red_Social
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Socialnetwork SN = new Socialnetwork("TheNewSocial", DateTime.Now);

        public MainWindow()
        {
            if (SN.GetListUser().Count() == 0)
            {
                _ = SN.Register("Simon", "123");
                SN.Logout();

                _ = SN.Register("Maria", "abc");
                SN.Logout();

                _ = SN.Register("Carlos", "1a2b3c4d");
                SN.Logout();

                _ = SN.Register("Laura", "contraseña");
                SN.Logout();

                _ = SN.Register("Anonimo", "****");
                SN.Logout();
            }

            InitializeComponent();
        }

        private void Aceppt_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string pass = Password.Text;

            if (SN.Login(name, pass))
            {
                Hide();

                Interaccion I = new Interaccion();
                I.Show();

            }
            else
            {
                _ = MessageBox.Show("Error, el usuario no existe");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Register R = new Register();
            R.Show();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
