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
    /// Lógica de interacción para AbrirComentario.xaml
    /// </summary>
    public partial class AbrirComentario : Window
    {
        public static ListBox ListaDeComentarios;
        public AbrirComentario()
        {
            InitializeComponent();

            Comment comentarios = (Comment)AbrirPost.ListaDeComentarios.SelectedItem;

            Contenido.Text = comentarios.Content;
            Likes.Text = Convert.ToString(comentarios.Like);
            Autor.Text = comentarios.Author.Name;
            FechaPublicacion.Text = comentarios.Date.ToString();

            List<Comment> listComentarios = new List<Comment>();
            listComentarios.Add(new Comment() { Id = "ID", Content = "Comentarios" });
            foreach (Comment comment in comentarios.ListComment)
            {
                listComentarios.Add(comment);
            }
            ListComentarios.ItemsSource = listComentarios;
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
            ComentarComentario C = new ComentarComentario();
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
                    AbrirPost.ListaDeComentarios = ListComentarios;
                    AbrirComentario ACC = new AbrirComentario();
                    ACC.Show();
                }
            }
            else
            {
                _ = MessageBox.Show("Debe elegir un comentario", "Error");
            }
        }
    }
}
