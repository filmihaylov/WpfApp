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
using WpfApp.DTOs;

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
            this.shipmentListGrid.ItemsSource = GetShipments(0, 25, 1);
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DbOpp db = new DbOpp();
            await Task.Run(() =>
            {
                db.CreateDummyData(1);
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = client.GetShipments(new Truck() { Id = 1 }, 0, 25);
            var t = "fdfdf";

            var b = client.GetPackages(new Shipment() { Id = 1 });
            var z = "fdfdf";
        }

        private void shipmentListGrid_CellClicked(object sender, MouseButtonEventArgs e)
        {
            DataGrid castedSender =  (DataGrid)sender;
            var selectedShipmentIdentifier = (ShipmentListDTO)castedSender.SelectedValue;
            int shipmentID = selectedShipmentIdentifier.Indentifier;
            var newForm = new ShipmentDetail(); 
            newForm.Show();
        }

        private List<ShipmentListDTO> GetShipments(int skip, int take, int truckId =1)
        {
            var shipments = client.GetShipments(new Truck() { Id = 1 }, 0, 25);
            List<ShipmentListDTO> shipmentDtos = new List<ShipmentListDTO>();
            foreach (var shipment in shipments)
            {
                var packages = client.GetPackages(shipment);
                shipmentDtos.Add(new ShipmentListDTO(shipment, packages.ToList()));
            }

            return shipmentDtos;
        }
    }
}
