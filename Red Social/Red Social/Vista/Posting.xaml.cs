﻿using System;
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
    /// Lógica de interacción para Posting.xaml
    /// </summary>
    public partial class Posting : Window
    {
        public Posting()
        {
            InitializeComponent();

            List<Usuario> listUser = new List<Usuario>();
            List<Usuario> listUser_Elegidos = new List<Usuario>();


            listUser.Add(new Usuario() { Name = "Nombre" });
            listUser_Elegidos.Add(new Usuario() { Name = "Nombre" });

            foreach (User user in MainWindow.SN.GetListUser())
            {
                if (!user.GetName().Equals(MainWindow.SN.SearchUserActive().GetName()))
                {
                    listUser.Add(new Usuario() { Name = user.GetName() });
                }
            }
            ListUser.ItemsSource = listUser;
            ListUser_Elegidos.ItemsSource = listUser_Elegidos;

        }
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            string content = Contenido.Text;
            if(ListUser_Elegidos.Items.Count > 1)
            {
                List<string> listString = new List<string>();
                List<Usuario> listUser_Elegidos = new List<Usuario>();
                
                foreach(Usuario user in ListUser_Elegidos.Items)
                {
                    listUser_Elegidos.Add(user);
                }

                for (int i = 1; i < listUser_Elegidos.Count; i++)
                {
                    Usuario user = listUser_Elegidos[i];
                    listString.Add(user.Name);
                }

                MainWindow.SN.Post("Text", content);
            }
            else
            {
                MainWindow.SN.Post("text", content);
            }
            

            Hide();
            Interaccion I = new Interaccion();
            I.Show();
        }

        private void Elegir_Click(object sender, RoutedEventArgs e)
        {
            List<Usuario> listUser = new List<Usuario>();
            List<Usuario> newListUser = new List<Usuario>();

            foreach(Usuario content in ListUser_Elegidos.Items)
            {
                newListUser.Add(content);
            }

            foreach (Usuario content in ListUser.Items)
            {
                if (content.Name.Equals("Nombre"))
                {
                    listUser.Add(content);
                }
                else if (content.Equals(ListUser.SelectedItem))
                {
                    newListUser.Add(content);
                }
                else
                {
                    listUser.Add(content);
                }
            }
            ListUser_Elegidos.ItemsSource = newListUser;
            ListUser.ItemsSource = listUser;
        }

        private void Retornar_Click(object sender, RoutedEventArgs e)
        {
            List<Usuario> listUser = new List<Usuario>();
            List<Usuario> newListUser = new List<Usuario>();

            foreach (Usuario content in ListUser.Items)
            {
                newListUser.Add(content);
            }

            foreach (Usuario content in ListUser_Elegidos.Items)
            {
                if (content.Name.Equals("Nombre"))
                {
                    listUser.Add(content);
                }
                else if (content.Equals(ListUser_Elegidos.SelectedItem))
                {
                    newListUser.Add(content);
                }
                else
                {
                    listUser.Add(content);
                }
            }
            ListUser.ItemsSource = newListUser;
            ListUser_Elegidos.ItemsSource = listUser;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Interaccion I = new Interaccion();
            I.Show();
        }
    }
    public class Usuario
    {
        public string Name { get; set; }
    }
}
