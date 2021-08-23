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

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Aceppt_Click(object sender, RoutedEventArgs e)
        {

            string pass = Password_Ocultar.Visibility.Equals(Visibility.Visible) ? Password_Ocultar.Password : Password_Mostrar.Text;

            if (!name.Text.Equals(""))
            {
                if (!pass.Equals(""))
                {
                    if (MainWindow.SN.Register(name.Text, pass))
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

        private void Es_Mo_Pass_Click(object sender, RoutedEventArgs e)
        {
            if (Esconder.Visibility.Equals(Visibility.Visible))
            {
                Password_Mostrar.Text = Password_Ocultar.Password;
                Password_Mostrar.Visibility = Visibility.Visible;
                Password_Ocultar.Visibility = Visibility.Hidden;
                Esconder.Visibility = Visibility.Hidden;
                Mostrar.Visibility = Visibility.Visible;
            }
            else if (Mostrar.Visibility.Equals(Visibility.Visible))
            {
                Password_Ocultar.Password = Password_Mostrar.Text;
                Password_Mostrar.Visibility = Visibility.Hidden;
                Password_Ocultar.Visibility = Visibility.Visible;
                Esconder.Visibility = Visibility.Visible;
                Mostrar.Visibility = Visibility.Hidden;
            }
        }

        private void Aceptar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                string pass = Password_Ocultar.Visibility.Equals(Visibility.Visible) ? Password_Ocultar.Password : Password_Mostrar.Text;

                if (!name.Text.Equals(""))
                {
                    if (!pass.Equals(""))
                    {
                        if (MainWindow.SN.Register(name.Text, pass))
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
        }
    }
}
