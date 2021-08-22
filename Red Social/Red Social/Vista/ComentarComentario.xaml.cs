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
    /// Lógica de interacción para ComentarComentario.xaml
    /// </summary>
    public partial class ComentarComentario : Window
    {
        public ComentarComentario()
        {
            InitializeComponent();

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            
            string content = Contenido.Text;
            if (!content.Equals(""))
            {
                Comment Comentario = (Comment)AbrirPost.ListaDeComentarios.SelectedItem;
                MainWindow.SN.Comment(Comentario, content);


                Hide();
                AbrirComentario AB = new AbrirComentario();
                AB.Show();
            }
            else
            {
                _ = MessageBox.Show("Debe añadir un contenido al comentarios", "Error");
            }
            
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AbrirComentario AB = new AbrirComentario();
            AB.Show();
        }
    }
}
