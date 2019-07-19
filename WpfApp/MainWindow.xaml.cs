using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WpfApp.ServiceReference1;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost host = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (host =
                        new ServiceHost(typeof(Service.Service1)))
                {
                    host.AddServiceEndpoint(typeof(Service.IService1),
                       new BasicHttpBinding(), "http://localhost:8733/Design_Time_Addresses/Service/Service1/");

                    host.Open();
                }
            }
            catch (Exception ex)
            {
                host.Abort();
                MessageBox.Show("Error = " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //test
            Service1Client client = new Service1Client();
            var a = client.GetData(7);
            MessageBox.Show(a);
            host.Close();
        }
    }
}
