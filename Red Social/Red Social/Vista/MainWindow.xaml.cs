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

                _ = SN.Login("Simon", "123");
                SN.Follow("Maria");
                SN.Follow("Carlos");
                SN.Follow("Laura");
                SN.Follow("Anonimo");
                SN.Logout();

                _ = SN.Login("Maria", "abc");
                SN.Follow("Simon");
                SN.Follow("Carlos");
                SN.Follow("Laura");
                SN.Follow("Anonimo");
                SN.Logout();

                _ = SN.Login("Carlos", "1a2b3c4d");
                SN.Follow("Simon");
                SN.Follow("Maria");
                SN.Follow("Laura");
                SN.Follow("Anonimo");
                SN.Logout();

                _ = SN.Login("Laura", "contraseña");
                SN.Follow("Simon");
                SN.Follow("Maria");
                SN.Follow("Carlos");
                SN.Follow("Anonimo");
                SN.Logout();

                _ = SN.Login("Anonimo", "****");
                SN.Follow("Simon");
                SN.Follow("Maria");
                SN.Follow("Carlos");
                SN.Follow("Laura");
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
                List<string> users = new List<string>();

                users.Add("Maria");
                users.Add("Carlos");
                users.Add("Laura");
                users.Add("Anonimo");
                _ = SN.Login("Simon", "123");
                SN.Post("text", "Este es el primer post dirijido a otros", users);
                SN.Logout();

                users.Clear();
                users.Add("Carlos");
                users.Add("Laura");
                users.Add("Anonimo");
                _ = SN.Login("Maria", "abc");
                SN.Post("text", "Este es el segundo post dirijido a otros", users);
                SN.Logout();

                users.Clear();
                users.Add("Laura");
                users.Add("Anonimo");
                _ = SN.Login("Carlos", "1a2b3c4d");
                SN.Post("text", "Este es el tercer post dirijido a otros", users);
                SN.Logout();

                users.Clear();
                users.Add("Anonimo");
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
            string pass = Password.Password;
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
    }
}
