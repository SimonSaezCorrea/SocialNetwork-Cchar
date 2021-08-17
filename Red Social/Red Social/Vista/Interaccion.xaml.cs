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
    /// Lógica de interacción para Interaccion.xaml
    /// </summary>
    public partial class Interaccion : Window
    {
        public static ListBox listaDePublicaciones;
        public Interaccion()
        {
            InitializeComponent();
            List<Post> listPublicaciones = new List<Post>();

            listPublicaciones.Add(new Post() { Id = "ID", Content = "Contenido", Author = new User() { Name = "Autor"} });

            foreach (Post post in MainWindow.SN.ListPost)
            {
                listPublicaciones.Add(post);
            }
            ListPost.ItemsSource = listPublicaciones;
            listaDePublicaciones = ListPost;
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SN.Logout();
            Hide();
            MainWindow MW = new MainWindow();
            MW.Show();
        }

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Posting P = new Posting();
            P.Show();
        }

        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            if(ListPost.SelectedItem != null)
            {
                int index = ListPost.SelectedIndex;
                if (index != 0)
                {
                    Hide();
                    AbrirPost AP = new AbrirPost();
                    AP.Show();
                }
            }
            else
            {
                _ = MessageBox.Show("Debe elegir una publicacion","Error");
            }  
        }

        private void Follow_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Seguir S = new Seguir();
            S.Show();

        }
    }
}
