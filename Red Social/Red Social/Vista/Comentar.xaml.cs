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
    /// Lógica de interacción para Comentar.xaml
    /// </summary>
    public partial class Comentar : Window
    {
        public Comentar()
        {
            InitializeComponent();
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            
            string content = Contenido.Text;
            if (!content.Equals(""))
            {
                Publicaciones publicacion = (Publicaciones)Interaccion.listaDePublicaciones.SelectedItem;
                Post post = MainWindow.SN.SearchPost(Convert.ToInt32(publicacion.Id));
                MainWindow.SN.Comment(post, content);

                Hide();
                Interaccion I = new Interaccion();
                I.Show();
            }
            else
            {
                _ = MessageBox.Show("Debe añadir un contenido al comentario", "Error");
            }
           
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Interaccion I = new Interaccion();
            I.Show();
        }
    }
}
