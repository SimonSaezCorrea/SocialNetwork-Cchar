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
            if (SN.ListUser.Count() == 0)
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

                User user1 = SN.SearchUser(1);
                User user2 = SN.SearchUser(2);
                User user3 = SN.SearchUser(3);
                User user4 = SN.SearchUser(4);
                User user5 = SN.SearchUser(5);



                _ = SN.Login("Simon", "123");
                SN.Follow(user2);
                SN.Follow(user3);
                SN.Follow(user4);
                SN.Follow(user5);
                SN.Logout();

                _ = SN.Login("Maria", "abc");
                SN.Follow(user1);
                SN.Follow(user3);
                SN.Follow(user4);
                SN.Follow(user5);
                SN.Logout();

                _ = SN.Login("Carlos", "1a2b3c4d");
                SN.Follow(user1);
                SN.Follow(user2);
                SN.Follow(user4);
                SN.Follow(user5);
                SN.Logout();

                _ = SN.Login("Laura", "contraseña");
                SN.Follow(user1);
                SN.Follow(user2);
                SN.Follow(user3);
                SN.Follow(user5);
                SN.Logout();

                _ = SN.Login("Anonimo", "****");
                SN.Follow(user1);
                SN.Follow(user2);
                SN.Follow(user3);
                SN.Follow(user4);
                SN.Logout();


                // Se hacen los post a su misma cuenta
                _ = SN.Login("Simon", "123");
                SN.Post("text", "Este es el primer post");
                SN.Logout();

                _ = SN.Login("Maria", "abc");
                SN.Post("text", "Este es el segundo post");
                SN.Logout();

                _ = SN.Login("Carlos", "1a2b3c4d");
                SN.Post("text", "Este es el tercer post");
                SN.Logout();

                _ = SN.Login("Laura", "contraseña");
                SN.Post("text", "Este es el cuarto post");
                SN.Logout();

                _ = SN.Login("Anonimo", "****");
                SN.Post("text", "Este es el quinto post");
                SN.Logout();

                // Se hacen post a cuentas de otros
                List<User> users = new List<User>();

                users.Add(user2);
                users.Add(user3);
                users.Add(user4);
                users.Add(user5);
                _ = SN.Login("Simon", "123");
                SN.Post("text", "Este es el primer post dirijido a otros", users);
                SN.Logout();

                users.Clear();
                users.Add(user3);
                users.Add(user4);
                users.Add(user5);
                _ = SN.Login("Maria", "abc");
                SN.Post("text", "Este es el segundo post dirijido a otros", users);
                SN.Logout();

                users.Clear();
                users.Add(user4);
                users.Add(user5);
                _ = SN.Login("Carlos", "1a2b3c4d");
                SN.Post("text", "Este es el tercer post dirijido a otros", users);
                SN.Logout();

                users.Clear();
                users.Add(user5);
                _ = SN.Login("Laura", "contraseña");
                SN.Post("text", "Este es el cuarto post dirijido a otros", users);
                SN.Logout();

                // Se hacen los comentarios a publicaciones
                Post publicaciones;

                _ = SN.Login("Simon", "123");
                publicaciones = SN.SearchPost(1);
                SN.Comment(publicaciones, "Este es el primer comentario a un post");
                SN.Logout();

                _ = SN.Login("Maria", "abc");
                publicaciones = SN.SearchPost(2);
                SN.Comment(publicaciones, "Este es el segundo comentario a un post");

                _ = SN.Login("Carlos", "1a2b3c4d");
                publicaciones = SN.SearchPost(3);
                SN.Comment(publicaciones, "Este es el tercer comentario a un post");
                SN.Logout();

                _ = SN.Login("Laura", "contraseña");
                publicaciones = SN.SearchPost(4);
                SN.Comment(publicaciones, "Este es el cuarto comentario a un post");
                SN.Logout();

                _ = SN.Login("Anonimo", "****");
                publicaciones = SN.SearchPost(5);
                SN.Comment(publicaciones, "Este es el quinto comentario a un post");
                SN.Logout();

                // Se hacen los comentarios a comentarios
                Comment comentarios;

                _ = SN.Login("Simon", "123");
                comentarios = SN.SearchComment(1);
                SN.Comment(comentarios, "Este es el primer comentario a un comentario");
                SN.Logout();

                _ = SN.Login("Maria", "abc");
                comentarios = SN.SearchComment(2);
                SN.Comment(comentarios, "Este es el segundo comentario a un comentario");
                SN.Logout();

                _ = SN.Login("Carlos", "1a2b3c4d");
                comentarios = SN.SearchComment(3);
                SN.Comment(comentarios, "Este es el tercer comentario a un comentario");
                SN.Logout();

                _ = SN.Login("Laura", "contraseña");
                comentarios = SN.SearchComment(4);
                SN.Comment(comentarios, "Este es el cuarto comentario a un comentario");
                SN.Logout();

                _ = SN.Login("Anonimo", "****");
                comentarios = SN.SearchComment(5);
                SN.Comment(comentarios, "Este es el quinto comentario a un comentario");
                SN.Logout();
            }

            InitializeComponent();

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Aceppt_Click(object sender, RoutedEventArgs e)
        {
            string names = name.Text;
            string pass = Password_Ocultar.Visibility.Equals(Visibility.Visible) ? Password_Ocultar.Password : Password_Mostrar.Text;

            if (!names.Equals(""))
            {
                if (!pass.Equals(""))
                {
                    if (SN.Login(names, pass))
                    {
                        Hide();

                        Interaccion I = new Interaccion();
                        I.Show();

                    }
                    else
                    {
                        _ = MessageBox.Show("El usuario no existe", "");
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
                string names = name.Text;
                string pass = Password_Ocultar.Visibility.Equals(Visibility.Visible) ? Password_Ocultar.Password : Password_Mostrar.Text;

                if (!names.Equals(""))
                {
                    if (!pass.Equals(""))
                    {
                        if (SN.Login(names, pass))
                        {
                            Hide();

                            Interaccion I = new Interaccion();
                            I.Show();

                        }
                        else
                        {
                            _ = MessageBox.Show("El usuario no existe", "");
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
