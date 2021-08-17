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
            Publicaciones publicacion = (Publicaciones)Interaccion.listaDePublicaciones.SelectedItem;
            Post post = MainWindow.SN.SearchPost(Convert.ToInt32(publicacion.Id));

            Contenido.Text = post.GetContent();
            Likes.Text = Convert.ToString(post.GetLike());
            Autor.Text = post.GetAuthor().GetName();
            CantShares.Text = Convert.ToString(post.GetAmountShare());
            FechaPublicacion.Text = post.GetDate().ToString();
            
            List<Comentarios> listPoblaciones = new List<Comentarios>();
            listPoblaciones.Add(new Comentarios() {Id = "ID", Content = "Comentarios" });
            foreach (Comment comment in post.GetListComment())
            {
                listPoblaciones.Add(new Comentarios() { Id = Convert.ToString(comment.GetId()), Content = comment.GetContent() });
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
    public class Comentarios
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
}
