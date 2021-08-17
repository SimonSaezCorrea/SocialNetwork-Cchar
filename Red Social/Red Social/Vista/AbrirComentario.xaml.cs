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

            Comentarios comentarios = (Comentarios)AbrirPost.ListaDeComentarios.SelectedItem;
            Comment comment = MainWindow.SN.SearchComment(Convert.ToInt32(comentarios.Id));

            Contenido.Text = comment.GetContent();
            Likes.Text = Convert.ToString(comment.GetLike());
            Autor.Text = comment.GetAuthor().GetName();
            FechaPublicacion.Text = comment.GetDate().ToString();

            List<Comentarios> listComentarios = new List<Comentarios>();
            listComentarios.Add(new Comentarios() { Id = "ID", Content = "Comentarios" });
            foreach (Comment com in comment.GetListComment())
            {
                listComentarios.Add(new Comentarios() { Id = Convert.ToString(com.GetId()), Content = com.GetContent() });
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
