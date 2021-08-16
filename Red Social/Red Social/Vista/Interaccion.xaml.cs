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
        public Interaccion()
        {
            InitializeComponent();
            List<Publicaciones> listPoblaciones = new List<Publicaciones>();

            listPoblaciones.Add(new Publicaciones() { Id = "ID", Content = "Contenido", Autor = "Autor" });

            foreach (Post post in MainWindow.SN.GetListPost())
            {
                listPoblaciones.Add(new Publicaciones() { Id = Convert.ToString(post.GetId()), Content = post.GetContent(), Autor = post.GetAuthor().GetName() });
            }
            ListPost.ItemsSource = listPoblaciones;
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
    }

    public class Publicaciones
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Autor { get; set; }
    }
}
