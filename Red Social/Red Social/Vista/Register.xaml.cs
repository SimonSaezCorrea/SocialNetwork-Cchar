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
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {

        public Register()
        {
            InitializeComponent();
        }

        private void Aceppt_Click(object sender, RoutedEventArgs e)
        {
            if (!Name.Text.Equals(""))
            {
                if (!Password.Password.Equals(""))
                {
                    if (MainWindow.SN.Register(Name.Text, Password.Password))
                    {
                        Hide();

                        Interaccion I = new Interaccion();
                        I.Show();
                    }
                    else
                    {
                        _ = MessageBox.Show("El usuario existe");
                    }
                }
                else
                {
                    _ = MessageBox.Show("Debe añadir una contraseña", "Error");
                }
            }
            else
            {
                _ = MessageBox.Show("Debe añadir un usuario", "Error");
            }
            
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow MW = new MainWindow();
            MW.Show();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow MW = new MainWindow();
            MW.Show();
        }
    }
}
