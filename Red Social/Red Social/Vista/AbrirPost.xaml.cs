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
    /// Lógica de interacción para AbrirPost.xaml
    /// </summary>
    public partial class AbrirPost : Window
    {
        public static ListBox ListaDeComentarios;
        public AbrirPost()
        {
            InitializeComponent();
            Post publicacion = (Post)Interaccion.listaDePublicaciones.SelectedItem;

            Contenido.Text = publicacion.Content;
            Likes.Text = Convert.ToString(publicacion.Like);
            Autor.Text = publicacion.Author.Name;
            CantShares.Text = Convert.ToString(publicacion.AmountShare);
            FechaPublicacion.Text = publicacion.Date.ToString();
            
            List<Comment> listPoblaciones = new List<Comment>();
            listPoblaciones.Add(new Comment() {Id = "ID", Content = "Comentarios" });
            foreach (Comment comment in publicacion.ListComment)
            {
                listPoblaciones.Add(comment);
            }
            ListComentarios.ItemsSource = listPoblaciones;
            ListaDeComentarios = ListComentarios;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Interaccion I = new Interaccion();
            I.Show();
        }

        private void Comentar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Comentar C = new Comentar();
            C.Show();
        }

        private void VerComentario_Click(object sender, RoutedEventArgs e)
        {
            if (ListComentarios.SelectedItem != null)
            {
                int index = ListComentarios.SelectedIndex;
                if (index != 0)
                {
                    Hide();
                    AbrirComentario AC = new AbrirComentario();
                    AC.Show();
                }
            }
            else
            {
                _ = MessageBox.Show("Debe elegir un comentario", "Error");
            }
        }
    }
}
