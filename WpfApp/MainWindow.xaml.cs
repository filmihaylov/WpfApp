using Data;
using Data.Database;
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
using WpfApp.DeliveryService;


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DeliveryServiceClient client = new DeliveryServiceClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Truck t = new Truck();

            t.Id = 1;


            var a = client.GetShipments(t, 0, 1);

            foreach(var b in a)
            {
                var c = b.Id;
            }
            //DbOpp db = new DbOpp();
            //db.CreateDummyData(1);
        }
    }
}
