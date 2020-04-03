using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckpointA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WebClient Client { get; set; }
        public MainWindow()
        {           
            InitializeComponent();
            var host = new NancyHost(new Uri("http://localhost:1234"));
            host.Start();
            Client = new WebClient();
        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = String.Empty;
            string file = "http://localhost:1234/file/" + TextBox_FilePath.Text;
            var result = Client.DownloadString(file);
            textBlock.Text = result;
            TextBox_FilePath.Text = String.Empty;
        }

        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
            textBlock.Text = String.Empty;
            string file = "http://localhost:1234/file/" + TextBox_FilePath.Text;
            var result = Client.UploadString(file, "DELETE", "");
            textBlock.Text = result;
            TextBox_FilePath.Text = String.Empty;
        }

        private void Put_Click_2(object sender, RoutedEventArgs e)
        {
            textBlock.Text = String.Empty;
            string file = "http://localhost:1234/file/" + TextBox_FilePath.Text;
            var result = Client.UploadString(file, "PUT", "");
            textBlock.Text = result;
            TextBox_FilePath.Text = String.Empty;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
