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
        public static List<ListBox> ListaDeComentariosAnterior;
        public AbrirComentario()
        {

            InitializeComponent();

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

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

            if (ListaDeComentariosAnterior == null)
            {
                ListaDeComentariosAnterior = new List<ListBox>();
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            if(ListaDeComentariosAnterior == null || ListaDeComentariosAnterior.Count == 0)
            {
                Hide();
                AbrirPost AP = new AbrirPost();
                AP.Show();
            }
            else
            {
                Console.WriteLine("Cantidad = "+ ListaDeComentariosAnterior.Count);
                AbrirPost.ListaDeComentarios = ListaDeComentariosAnterior[ListaDeComentariosAnterior.Count - 1];
                Console.WriteLine("Cantidad = "+ ListaDeComentariosAnterior.Count);
                ListaDeComentariosAnterior.RemoveAt(ListaDeComentariosAnterior.Count - 1);
                Console.WriteLine("Cantidad = "+ ListaDeComentariosAnterior.Count+"\n\n");
                Hide();
                AbrirComentario I = new AbrirComentario();
                I.Show();
            }
            
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
                    ListaDeComentariosAnterior.Add(AbrirPost.ListaDeComentarios);
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
        private void Like_Click(object sender, RoutedEventArgs e)
        {
            int likes = Convert.ToInt32(Likes.Text);
            if (MainWindow.SN.Like((Comment)AbrirPost.ListaDeComentarios.SelectedItem))
            {
                likes += 1;
                Likes.Text = Convert.ToString(likes);
            }
        }
    }
}
